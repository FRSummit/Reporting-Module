using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface IDiffService
    {
        string GetDiff(DiffCandidate diffCandidate);
        string GetDiff(string left, string right);
    }
}