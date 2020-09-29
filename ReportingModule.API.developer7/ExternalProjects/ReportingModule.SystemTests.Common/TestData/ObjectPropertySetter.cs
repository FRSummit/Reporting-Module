using System;
using System.Reflection;

namespace ReportingModule.SystemTests.Common.TestData
{
	public static class ObjectPropertySetter
	{
		public static T CreateObjectWithAllPropertiesSet<T>()
		{
			return (T)CreateObjectWithAllPropertiesSet(typeof (T));
		}

		public static object CreateObjectWithAllPropertiesSet(Type type)
		{
			var entity = type.GetConstructor(new Type[0]).Invoke(null);

			PropertyInfo[] allProperties = type.GetProperties();

			foreach (var property in allProperties)
			{
				Type propType = property.PropertyType;
				if (!propType.IsArray)
				{
					if (property.GetSetMethod() != null)
					{
						var value = DataProvider.Get(propType, true);
						property.SetValue(entity, value, null);
					}
				}
			}

			return entity;
		}
	}
}