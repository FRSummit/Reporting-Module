using System.Web;
using System.Web.Http;

namespace ReportingModule.Website
{
    public class WebApiApplication : HttpApplication
    {
        private NsbService _nsbService;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            _nsbService = new NsbService();
            _nsbService.Start();
        }

        protected void Application_End()
        {
            _nsbService?.Stop();
        }
    }
}