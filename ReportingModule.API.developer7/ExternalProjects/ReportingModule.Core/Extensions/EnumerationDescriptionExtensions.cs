using System;
using ReportingModule.Utility;
using ReportingModule.Utility.Attributes;

namespace ReportingModule.Core.Extensions
{
	public static class EnumerationDescriptionExtensions
	{
		public static string GetDescriptionSpacedByCamelCasing(this Enum en, bool ignoreAcronynms = true)
		{
			var description = Enum.GetName(en.GetType(), en);

			if (ignoreAcronynms && description == description.ToUpper())
			{
				return description;
			}

			return description.GetWithSpacesByCamelCasing();
		}

		/// <summary>
		/// Returns a string value for the enumeration based on the PropertyName attribute assigned to the enum's fields
		/// </summary>
		public static string GetDescription(this Enum en, string defaultValue = null, bool useCamelCaseIfNoPropertyName = true)
		{
			if (en == null) return defaultValue;

			var type = en.GetType();

			var memInfo = type.GetMember(en.ToString());

			if (memInfo.Length > 0)
			{
				var attr = 
					(PropertyNameAttribute)Attribute.GetCustomAttribute(memInfo[0], typeof(PropertyNameAttribute));

				if (attr != null)
				{
					return attr.PropertyName;
				}
				
				if (useCamelCaseIfNoPropertyName)
				{
					return en.GetDescriptionSpacedByCamelCasing();
				}
			}

			return en.ToString();
		}
	}
}