using System;
using Newtonsoft.Json;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace ReportingModule.Core
{
	public class Option<T>
    {
        public T Value { get; private set; }

        public bool IsSome { get; private set; }

		private Option()
		{
			Value = default(T);
			IsSome = false;
		}

        [JsonConstructor]
        private Option(T value, bool isSome)
        {
            Value = value;
            IsSome = isSome;
        }

        public static Option<T> Some(T value) => new Option<T>(value, true); 

        public static readonly Option<T> None = new Option<T>();

	    [JsonIgnore]
		public bool IsNone => !IsSome;

        //TODO: EH31.10.2017 remove implicit operator and refactor usages (OceanInsightsRouteResult + tests)
        public static implicit operator Option<T>(T value) => new Option<T>(value, true);
    }

	public static class OptionExtensions
	{
		public static void Apply<T>(this Option<T> option, Action<T> applyAction)
		{
            if (option != null && option.IsSome && option.Value != null)
            {
                applyAction(option.Value);
			}
        }
    }
}