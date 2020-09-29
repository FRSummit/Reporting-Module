using System;
using System.Reflection;
using Microsoft.AspNet.SignalR.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace ReportingModule.Website
{
    internal class SignalRCamelCaseContractResolver : IContractResolver
    {
        private readonly Assembly _assembly;
        private readonly IContractResolver _camelCaseContractResolver;
        private readonly IContractResolver _defaultContractSerializer;

        public SignalRCamelCaseContractResolver()
        {
            _defaultContractSerializer = new DefaultContractResolver();
            _camelCaseContractResolver = new CamelCasePropertyNamesContractResolver();
            _assembly = typeof(Connection).Assembly;
        }

        public JsonContract ResolveContract(Type type)
        {
            // We can't use camelcasing on any internal SignalR types 
            // so these must be explicitly excluded
            return type.Assembly.Equals(_assembly)
                ? _defaultContractSerializer.ResolveContract(type)
                : _camelCaseContractResolver.ResolveContract(type);
        }
    }
}