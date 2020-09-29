using ReportingModule.Entities;

namespace ReportingModule.Services
{
    public interface IReportingIdentifierProvider
    {
        string GetNextIdentifier(IdentifierType identifierType);
    }
}