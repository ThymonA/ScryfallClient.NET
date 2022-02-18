using System.Collections.Generic;

namespace ScryfallAPI
{
    using System;
    using System.Net.Http;
    using System.Linq;

    public static class HttpRequestExtensions
    {
        public static bool Contains(this HttpRequestOptions options, string search, StringComparison comparisonType = StringComparison.InvariantCulture)
        {
            return options.IsNullOrDefault() ? default : options.Any(x => x.Key.Equals(search, comparisonType));
        }

        public static object Get(this HttpRequestOptions options, string search, StringComparison comparisonType = StringComparison.InvariantCulture)
        {
            if (options.IsNullOrDefault()) { return null; }

            var result = options.FirstOrDefault(x => x.Key.Equals(search, comparisonType));

            return result.IsNullOrDefault() ? null : result.Value;
        }

        public static void Set<TValue>(this HttpRequestOptions options, string search, TValue value, StringComparison comparisonType = StringComparison.InvariantCulture)
        {
            if (options.IsNullOrDefault()) { return; }

            var result = options.FirstOrDefault(x => x.Key.Equals(search, comparisonType));

            if (result.IsNullOrDefault()) { return; }

            var newValue = new HttpRequestOptionsKey<TValue>(result.Key);

            options.Set(newValue, value);
        }

        public static void Set<TValue>(this HttpRequestOptions options, KeyValuePair<string, TValue> keyValue, StringComparison comparisonType = StringComparison.InvariantCulture)
        {
            if (options.IsNullOrDefault() || keyValue.IsNullOrDefault()) { return; }

            var result = options.FirstOrDefault(x => x.Key.Equals(keyValue.Key, comparisonType));

            if (result.IsNullOrDefault()) { return; }

            var newValue = new HttpRequestOptionsKey<TValue>(result.Key);

            options.Set(newValue, keyValue.Value);
        }
    }
}
