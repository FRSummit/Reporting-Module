using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportingModule.Utility
{
    public static class HashCodeGenerator
    {
        public static int GenerateHashCode(this IEnumerable<object> objects)
        {
            if (!objects.Any())
                throw new InvalidOperationException("Cannot generate a hash code from nothing");
            unchecked
            {
                var hash = 17;
                foreach (var o in objects)
                    hash = 31*hash + (o?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}