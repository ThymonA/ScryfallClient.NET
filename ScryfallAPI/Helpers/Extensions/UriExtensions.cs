﻿namespace ScryfallAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class UriExtensions
    {
        public static Uri ApplyParameters(this Uri uri, IDictionary<string, string> parameters)
        {
            uri.ArgumentNotNull(nameof(uri));

            if (parameters == null || !parameters.Any())
            {
                return uri;
            }

            IDictionary<string, string> p = new Dictionary<string, string>(parameters);

            var hasQueryString = uri.OriginalString.IndexOf("?", StringComparison.Ordinal);

            var uriWithoutQuery = hasQueryString == -1
                ? uri.ToString()
                : uri.OriginalString.Substring(0, hasQueryString);

            string queryString;

            if (uri.IsAbsoluteUri)
            {
                queryString = uri.Query;
            }
            else
            {
                queryString = hasQueryString == -1
                    ? string.Empty
                    : uri.OriginalString.Substring(hasQueryString);
            }

            var values = queryString.Replace("?", string.Empty)
                                    .Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            var existingParameters = values.ToDictionary(
                        key => key.Substring(0, key.IndexOf('=')),
                        value => value.Substring(value.IndexOf('=') + 1));

            foreach (var existing in existingParameters)
            {
                if (!p.ContainsKey(existing.Key))
                {
                    p.Add(existing);
                }
            }

            Func<string, string, string> mapValueFunc = (key, value) => key == "q" ? value : Uri.EscapeDataString(value);

            var query = string.Join("&", p.Select(kvp => kvp.Key + "=" + mapValueFunc(kvp.Key, kvp.Value)));

            if (uri.IsAbsoluteUri)
            {
                var uriBuilder = new UriBuilder(uri)
                {
                    Query = query
                };
                return uriBuilder.Uri;
            }

            return new Uri(uriWithoutQuery + "?" + query, UriKind.Relative);
        }
    }
}
