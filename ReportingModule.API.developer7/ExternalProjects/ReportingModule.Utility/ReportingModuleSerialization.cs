using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ReportingModule.Utility
{
	public static class ReportingModuleSerialization
	{
		public static string SerializeViewModel(this object viewModel, JsonSerializerSettings settings = null)
		{
			return JsonConvert.SerializeObject(viewModel, Formatting.None, settings ?? JsonSerializerSettings);
		}

		// To Deserialized Event use: DeserializeWithStandardSettings
		public static string SerializeMessage(this object nsbEvent)
		{
			var dateConverter = new IsoDateTimeConverter();
			var jsonSerializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				TypeNameHandling = TypeNameHandling.All,
				TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
				Converters = new List<JsonConverter> {dateConverter}
			};

			return JsonConvert.SerializeObject(nsbEvent, Formatting.None, jsonSerializerSettings);
		}

		public static JsonSerializerSettings JsonSerializerSettings
		{
			get
			{
				var dateConverter = new IsoDateTimeConverter();
				var jsonSerializerSettings = new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver(),
					TypeNameHandling = TypeNameHandling.Auto,
					TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
					Converters = new List<JsonConverter> {dateConverter}
				};
				return jsonSerializerSettings;
			}
		}

		public static JsonSerializerSettings JsonSerializerSettingsForKendoGridReturnData
		{
			get
			{
				var dateConverter = new IsoDateTimeConverter();
				var jsonSerializerSettings = new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.None,
					Converters = new List<JsonConverter> {dateConverter}
				};
				return jsonSerializerSettings;
			}
		}

		public static object DeserializeWithStandardSettings(this string viewModel)
		{
			try
			{
				return JsonConvert.DeserializeObject(viewModel, JsonSerializerSettings);
			}
			catch (ArgumentNullException anex)
			{
				if (anex.InnerException != null)
				{
					throw anex.InnerException;
				}
				throw;
			}
			catch (TargetInvocationException tiex)
			{
				if (tiex.InnerException != null)
				{
					throw tiex.InnerException;
				}
				throw;
			}
		}

		public static T DeserializeViewModel<T>(this string viewModel)
		{
			try
			{
				return JsonConvert.DeserializeObject<T>(viewModel, JsonSerializerSettings);
			}
			catch (TargetInvocationException tiex)
			{
				if (tiex.InnerException != null)
				{
					throw tiex.InnerException;
				}
				throw;
			}
		}

		public static bool TryDeserializeUtcTime(this string utcTimeIn, out DateTime utcTime)
		{
			try
			{
				utcTime = utcTimeIn
					.DeserializeViewModel<DateTime>()
					.ToUniversalTime();
				return true;
			}
			catch (JsonReaderException)
			{
				utcTime = new DateTime();
				return false;
			}
		}
	}
}