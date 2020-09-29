using System;
using System.Threading;
using StructureMap;

namespace ReportingModule.Core.Configuration
{
    public static class ObjectFactory
	{
        private static readonly object LockObject = new object();

        // ContainerBuilder should only ever come into existence on the website.
        // On NSB (at time of writing, only the Report Generation Endpoint),
        // the Container is set using Container.Set
        public static Lazy<Container> ContainerBuilder =
			new Lazy<Container>(DefaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IContainer _container;
		public static IContainer Container
		{
			get { return _container ?? (_container = ContainerBuilder.Value); }
            set { _container = value; }
		}

        private static Container DefaultContainer()
        {
            var container = new Container();
            container.Name = "ObjectFactory-" + container.Name;
            return container;
        }

        public static void Initialize(Action<ConfigurationExpression> action = null)
        {
            if (action == null)
                return;

            lock (LockObject)
            {
                _container = null;
                var container = DefaultContainer();
                container.Configure(action);
                ContainerBuilder = new Lazy<Container>(() => container);
            }
        }

	    public static T GetInstance<T>()
		{
            return Container.GetInstance<T>();
		}

		public static object GetInstance(Type pluginType)
		{
			return Container.GetInstance(pluginType);
		}

        public static T TryGetInstance<T>()
	    {
	        return Container.TryGetInstance<T>();
	    }

	    public static object TryGetInstance(Type pluginType)
	    {
	        return Container.TryGetInstance(pluginType);
	    }

        public static void BuildUp(object obj)
        {
            Container.BuildUp(obj);
        }

        public static void Configure(Action<ConfigurationExpression> configure)
        {
            Container.Configure(configure);
        }
	}
}