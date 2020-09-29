using System.Collections.Generic;
using System.Linq;
using NHibernate;
using ReportingModule.Entities;

namespace ReportingModule.Services.Impl
{
    public class ReportingIdentifierProvider : IReportingIdentifierProvider
    {
        private readonly ISession _session;

        public static readonly IDictionary<IdentifierType, string> Prefixes
            = new Dictionary<IdentifierType, string>
            {
                [IdentifierType.ReportingItem] = "RI",
            };

        public ReportingIdentifierProvider(ISession session)
        {
            _session = session;
        }

        public string GetNextIdentifier(IdentifierType identifierType)
        {
            return $"{Prefixes[identifierType]}{GetCurrentIdentifier(identifierType):D8}";
        }

        private int GetCurrentIdentifier(IdentifierType identifierType)
        {
            var identifier = _session.Query<Identifier>()
                .SingleOrDefault(o => o.IdentifierType == identifierType);

            if (identifier == null)
            {
                identifier = new Identifier(identifierType);
                _session.Save(identifier);
            }

            var currentIndex = identifier.CurrentIndex;

            identifier.IncrementIndex();

            return currentIndex;
        }
    }
}