using NsbWeb.Core.AutoComplete;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using ReportingModule.Utility;

namespace NsbWeb.Core.Extensions
{
    public static class ApiControllerExtensions
    {
        public static JsonResult<T> ToJson<T>(this T obj, ApiController controller)
        {
            return new JsonResult<T>(obj, 
                ReportingModuleSerialization.JsonSerializerSettings, 
                new UTF8Encoding(false, true),
                controller);
        }

        public static JsonResult<LookupResult<T>> WrapLookupResult<T>(this T obj, ApiController controller)
        {
            return ToJson(new LookupResult<T> {D = obj}, controller);
        }
    }
}