using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace ReportingModule.Website
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            //config.Filters.Add(new AuthorizeAttribute());

            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
        }
    }
}