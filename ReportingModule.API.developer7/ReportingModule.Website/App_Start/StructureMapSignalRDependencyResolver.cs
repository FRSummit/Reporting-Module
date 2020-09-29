using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;

namespace ReportingModule.Website
{
    internal class StructureMapSignalRDependencyResolver : DefaultDependencyResolver
    {
        public override object GetService(Type serviceType)
        {
            if (typeof(Hub).IsAssignableFrom(serviceType))
            {
                return Ioc.Container.GetInstance(serviceType);
            }

            return Ioc.Container.TryGetInstance(serviceType)
                   ?? base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return new[] { Ioc.Container.TryGetInstance(serviceType) }
                .Concat(base.GetServices(serviceType))
                .Where(o => o != null);
        }
    }
}