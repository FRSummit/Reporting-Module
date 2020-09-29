using FluentNHibernate.Mapping;
using FluentNHibernate.Mapping.Providers;

namespace ReportingModule.Core
{
    public static class JsonSerializedObjectTypeExtension
    {
        public static PropertyPart JsonSerialized(this PropertyPart propertyPart)
        {
            var jsonType = typeof(JsonSerializedObjectType<>);
            var propertyType = ((IPropertyMappingProvider)propertyPart).GetPropertyMapping().Member.PropertyType;

            var customType = jsonType.MakeGenericType(propertyType);

            return propertyPart.CustomType(customType);
        }
    }
}