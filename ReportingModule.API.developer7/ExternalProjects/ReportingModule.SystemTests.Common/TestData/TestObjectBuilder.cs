using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate;
using ReportingModule.Utility;

namespace ReportingModule.SystemTests.Common.TestData
{
    // Give it a type, and it will build an instance of that type, using the greedy constructor algorithm and
    // building parameters using the DataProvider.
    public class TestObjectBuilder<T>
    {
        private readonly Type _type;
        private readonly ParameterProvider _parameterProvider;
        private readonly ParameterInfo[] _parameterInfos;

        public TestObjectBuilder()
        {
            _type = typeof(T);
            _parameterProvider = new ParameterProvider();
            _parameterInfos = _type.GetConstructorWithMostParameters().GetParameters().ToArray();
        }

        public ParameterInfo[] ConstructorParameters => _parameterInfos;

        public TestObjectBuilder<T> SetArgument(string arg, object value)
        {
            if (!_parameterInfos.Select(x => x.Name).Contains(arg))
            {
                string msg =
                    string.Format(
                        "The constructor with the most parameters for type {0}, does not have a a parameter named {1}.",
                        _type.Name,
                        arg);

                throw new Exception(msg);
            }
            _parameterProvider.SetArgument(arg, value);
            return this;
        }

        public TestObjectBuilder<T> SetTypeProvider<T2>(Func<T2> provider)
        {
            _parameterProvider.SetTypeProvider(provider);
            return this;
        }

        public TestObjectBuilder<T> Clone(T entity)
        {
            _parameterInfos.ToList()
                .ForEach(paramInfo =>
                {
                    var paramName = paramInfo.Name;
                    var property =
                        _type.GetProperty(paramInfo.Name,
                            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public |
                            BindingFlags.IgnoreCase);
                    if (property == null)
                    {
                        throw new Exception(
                            "Clone will not work on this entity. For clone to work, each constructor parameter must have a correspondingly named property (case doesn't matter)");
                    }
                    var entityParamValue =
                        property.GetValue(entity, null);
                    SetArgument(paramName,
                        entityParamValue);
                });
            return this;
        }


        /// <summary>
        /// Sets an argument based on an expression to the Property name being set.
        /// Depends on the argument to the constructor being named consistently
        /// eg. string MyProperty { get; set; } => public MyClass(string myProperty)
        /// MyProperty => myProperty
        /// </summary>
        public TestObjectBuilder<T> SetArgument<TParam>(Expression<Func<T, TParam>> expr, TParam value)
        {
            var propertyName = MemberUtility.GetMemberInfo(expr).Name;
            var paramName = string.Format("{0}{1}",
                Char.ToLower(propertyName[0]),
                propertyName.Substring(1));

            return SetArgument(paramName, value);
        }

        public T Build()
        {
            var parameters = _parameterInfos
                .Select(p => _parameterProvider.GetValue(p))
                .ToArray();

            var constr = _type.GetConstructorWithMostParameters();
            return (T) constr.Invoke(parameters);
        }


        public T BuildAndPersist(ISession session)
        {
            var t = Build();
            session.Save(t);
            return t;
        }
    }

    public class MatchingObjectBuilder<TTestValue>
    {
        private readonly TestObjectVariationBuilder<TTestValue> _matches;
        private readonly TestObjectBuilder<TTestValue> _nonMatch;

        public MatchingObjectBuilder(TTestValue prototypicalObject)
        {
            _matches = new TestObjectVariationBuilder<TTestValue>(prototypicalObject);
            _nonMatch = new TestObjectBuilder<TTestValue>().Clone(prototypicalObject);
        }

        public MatchingObjectBuilder<TTestValue> SetMatchingProperty<TParam>(
            Expression<Func<TTestValue, TParam>> keepConstant)
        {
            _matches.KeepingConstant(keepConstant);
            _nonMatch.SetArgument(keepConstant, DataProvider.Get<TParam>());
            return this;
        }

        public Result Build()
        {
            return new Result(_matches.Build(), _nonMatch.Build());
        }

        public class Result
        {
            public Result(List<TTestValue> matches, TTestValue nonMatch)
            {
                Matches = matches;
                NonMatch = nonMatch;
            }

            public List<TTestValue> Matches { get; private set; }
            public TTestValue NonMatch { get; private set; }
        }
    }

    public class TestObjectVariationBuilder<TTestValue>
    {
        private readonly TTestValue _prototypicalObject;
        private readonly List<string> _constantProperties = new List<string>();


        public TestObjectVariationBuilder(TTestValue prototypicalObject)
        {
            _prototypicalObject = prototypicalObject;
        }

        public TestObjectVariationBuilder<TTestValue> KeepingConstant<TParam>(
            Expression<Func<TTestValue, TParam>> keepConstant)
        {
            var propertyName = MemberUtility.GetMemberInfo(keepConstant).Name;
            _constantProperties.Add(propertyName.ToLower());
            return this;
        }

        public List<TTestValue> Build()
        {
            IEnumerable<ParameterInfo> varyingParameters = new TestObjectBuilder<TTestValue>()
                .ConstructorParameters.Where(x => !_constantProperties.Contains(x.Name.ToLower()));

            List<TTestValue> entities =
                varyingParameters.Select(p =>
                    {
                        var propValue = DataProvider.Get(p.ParameterType);
                        var builder = new TestObjectBuilder<TTestValue>()
                            .Clone(_prototypicalObject)
                            .SetArgument(p.Name, propValue);
                        return builder.Build();
                    })
                    .ToList();
            return entities;
        }
    }
}