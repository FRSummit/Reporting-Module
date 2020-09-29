using System;

namespace ReportingModule.Utility.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PropertyNameAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public PropertyNameAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}