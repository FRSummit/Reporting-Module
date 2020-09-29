using Newtonsoft.Json.Linq;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class DiffService : IDiffService
    {
        public string GetDiff(DiffCandidate diffCandidate)
        {
            var jdp = new JsonDiffPatchDotNet.JsonDiffPatch();
            var left = JToken.Parse(diffCandidate.Left);
            var right = JToken.Parse(diffCandidate.Right);

            var patch = jdp.Diff(left, right);

            return patch?.ToString();
        }

        public string GetDiff(string left, string right)
        {
            var diffCandidate = new DiffCandidate(left, right);
            return GetDiff(diffCandidate);
        }
    }
}