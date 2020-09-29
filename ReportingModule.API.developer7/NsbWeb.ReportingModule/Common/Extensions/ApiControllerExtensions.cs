using System.Web.Http;

namespace NsbWeb.ReportingModule.Common.Extensions
{
    public static class ApiControllerExtensions
    {
        public static AcceptedResult Accepted(this ApiController apiController)
        {
            return new AcceptedResult();
        }
    }
}
