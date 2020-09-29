// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

using ReportingModule.Core.Domains;

namespace ReportingModule.Entities
{
    public class Identifier : IAggregate<int>
    {
        protected Identifier()
        {
        }

        public Identifier(IdentifierType identifierType)
        {
            IdentifierType = identifierType;
            CurrentIndex = 1;
        }

        public int Id { get; private set; }
        public IdentifierType IdentifierType { get; private set; }
        public int CurrentIndex { get; private set; }

        public void IncrementIndex()
        {
            CurrentIndex++;
        }
    }
}