namespace ScryfallAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionExtensions
    {
        public static TValue SafeGet<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
        {
            dictionary.ArgumentNotNull(nameof(dictionary));

            return dictionary.TryGetValue(key, out var value) ? value : default(TValue);
        }

        public static IList<string> Clone(this IReadOnlyList<string> input)
        {
            return input?.Select(item => new string(item.ToCharArray())).ToList();
        }

        public static IDictionary<string, Uri> Clone(this IReadOnlyDictionary<string, Uri> input)
        {
            return input?.ToDictionary(item => new string(item.Key.ToCharArray()), item => new Uri(item.Value.ToString()));
        }
    }
}
