using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace ReportingModule.Website
{
    public class ServiceActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = Ioc.Container.GetInstance(controllerType) as IHttpController;
            return controller;
        }
    }
}