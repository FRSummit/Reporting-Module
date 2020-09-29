using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Features;

namespace ReportingModule.Website
{
    public class NsbService
    {
        private IEndpointInstance _endpointInstance;
        public void Start()
        {
            AsyncStart().GetAwaiter().GetResult();
        }

        public void Stop()
        {
            _endpointInstance?.Stop().GetAwaiter().GetResult();
        }

        private async Task AsyncStart()
        {
            var endpointConfiguration = new EndpointConfiguration(EndpointConfig.ApiEndpointName);

            EndpointConfig.Customize(endpointConfiguration);
            endpointConfiguration.DisableFeature<Sagas>();
            _endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            Ioc.Container.Configure(x => x.For<IEndpointInstance>().Singleton().Use(_endpointInstance));
        }
    }
}