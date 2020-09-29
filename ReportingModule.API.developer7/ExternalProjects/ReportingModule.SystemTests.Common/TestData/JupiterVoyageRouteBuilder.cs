using System;
using System.Linq;
using ReportingModule.Core.OriginOperations;
using ReportingModule.Core.ShippingDomain;
using ReportingModule.Tests.Shared.Core.TestData;

namespace ReportingModule.SystemTests.Common.TestData
{
    public class JupiterVoyageRouteBuilder
    {
        private JupiterVoyageRoute.OriginLeg _originLeg;
        public JupiterVoyageRouteBuilder SetOriginLeg(JupiterVoyageRoute.OriginLeg originLeg)
        {
            _originLeg = originLeg;
            return this;
        }

        private JupiterVoyageRoute.LoadLeg _loadLeg;

        public JupiterVoyageRouteBuilder SetLoadLeg(JupiterVoyageRoute.LoadLeg loadLeg)
        {
            _loadLeg = loadLeg;
            return this;
        }
        
        private JupiterVoyageRoute.DischargeLeg _dischargeLeg;
        public JupiterVoyageRouteBuilder SetDischargeLeg(JupiterVoyageRoute.DischargeLeg dischargeLeg)
        {
            _dischargeLeg = dischargeLeg;
            return this;
        }

        private JupiterVoyageRoute.DestinationLeg _destinationLeg;
        public JupiterVoyageRouteBuilder SetDestinationLeg(JupiterVoyageRoute.DestinationLeg destinationLeg)
        {
            _destinationLeg = destinationLeg;
            return this;
        }

        public JupiterVoyageRouteBuilder FromRoute(JupiterVoyageRoute route)
        {
            _loadLeg = route.Load;
            _dischargeLeg = route.Discharge;
            return this;
        }

        public JupiterVoyageRoute Build()
        {
            return new JupiterVoyageRoute(
                _originLeg,
                _loadLeg ?? new JupiterVoyageRoute.LoadLeg(DataProvider.Get<string>(),
                    DateTime.Today,
                    DataProvider.Get<VesselReference>(),
                    DataProvider.GetStringOfLength(6)),
                new JupiterVoyageRoute.TranshipmentLeg[0], 
                _dischargeLeg ?? new JupiterVoyageRoute.DischargeLeg(DataProvider.Get<string>(),
                    DateTime.Today.AddDays(1)),
                _destinationLeg);
        }

        public static JupiterVoyageRoute MakeJupiterVoyageRouteFromPorts(string originPortCode, string destinationPortCode, params string[] transhipmentPortCodes)
        {
            return new JupiterVoyageRoute(null,
                new JupiterVoyageRoute.LoadLeg(originPortCode,
                    DateTime.Today,
                    DataProvider.Get<VesselReference>(),
                    DataProvider.GetStringOfLength(6)),
                transhipmentPortCodes.Select(portCode => new TestObjectBuilder<JupiterVoyageRoute.TranshipmentLeg>()
                    .SetArgument(t => t.PortCode, portCode)
                    .SetArgument(t => t.Etd, null)
                    .SetArgument(t => t.Eta, null)
                    .SetArgument(t => t.Vessel, DataProvider.Get<VesselReference>())
                    .SetArgument(t => t.Voyage, DataProvider.GetStringOfLength(15))
                    .Build()),
                new JupiterVoyageRoute.DischargeLeg(destinationPortCode,
                    DateTime.Today.AddDays(1)),
                null);
        }
    }
}