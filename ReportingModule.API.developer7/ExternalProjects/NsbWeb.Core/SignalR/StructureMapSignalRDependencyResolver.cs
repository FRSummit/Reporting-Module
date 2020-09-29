using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using ReportingModule.Core.Configuration;

namespace NsbWeb.Core.SignalR
{
    internal class StructureMapSignalRDependencyResolver : DefaultDependencyResolver
    {
        public override object GetService(Type serviceType)
        {
            if (typeof(Hub).IsAssignableFrom(serviceType))
            {
                return ObjectFactory.GetInstance(serviceType);
            }

            return ObjectFactory.TryGetInstance(serviceType)
                   ?? base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return new[] {ObjectFactory.TryGetInstance(serviceType)}
                .Concat(base.GetServices(serviceType))
                .Where(o => o != null);
        }
    }
}