using System;

namespace ReportingModule.Utility
{
    public class BoolUtility
    {
        public static bool IsYesNo(string val)
        {
            if (string.IsNullOrWhiteSpace(val)) return false;
            var upperVal = val.ToUpperInvariant();
            if (upperVal.Equals("YES")) return true;
            if (upperVal.Equals("NO")) return true;
            return false;
        }

        public static bool ParseYesNo(string val)
        {
            if (string.IsNullOrWhiteSpace(val)) throw new ArgumentNullException("val");
            var upperVal = val.ToUpperInvariant();
            if (upperVal.Equals("YES")) return true;
            if (upperVal.Equals("NO")) return false;
            throw new FormatException(string.Format("{0} is not one of Yes|No", val));
        }
    }
}
