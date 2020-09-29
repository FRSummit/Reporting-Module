using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Owin;

namespace NsbWeb.Core.SignalR
{
    public static class SignalRConfigurator
    {
        private static bool EnableDetailedErrors =>
            bool.TryParse(ConfigurationManager.AppSettings["EnableSignalRDetailedErrors"],
                out var result)
            && result;

        public static void ConfigureSignalR(this IAppBuilder app, 
            Assembly[] externalAssembliesContainingHubs,
            bool enableJavascriptProxies)
        {
            externalAssembliesContainingHubs.ToList()
                .ForEach(o => AppDomain.CurrentDomain.Load(o.FullName));
            
            var resolver = new StructureMapSignalRDependencyResolver();

            resolver.Register(typeof(JsonSerializer),
                () => JsonSerializer.Create(SignalRSerializerSettings));
            
            GlobalHost.DependencyResolver = resolver;
            
            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = EnableDetailedErrors,
                Resolver = resolver,
                EnableJavaScriptProxies = enableJavascriptProxies
            };
            
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR(hubConfiguration);
            });
        }
        
        public static JsonSerializerSettings SignalRSerializerSettings
        {
            get
            {
                var dateConverter = new IsoDateTimeConverter();
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new SignalRCamelCaseContractResolver(),
                    TypeNameHandling = TypeNameHandling.Auto,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                    Converters = new List<JsonConverter> {dateConverter}
                };
                return jsonSerializerSettings;
            }
        }
    }
}
