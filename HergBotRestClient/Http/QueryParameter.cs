using System.Linq;

namespace HergBot.RestClient.Http
{
    /// <summary>
    /// A class to format URL parameters as a query string.
    /// </summary>
    public class QueryParameter : DataParameter, IHttpRequestParameter
    {
        /// <summary>
        /// Formats the key/value collection as a query string.
        /// </summary>
        /// <returns>The query string or an empty string.</returns>
        public string Format()
        {
            if (!_keyValuePairs.Any())
            {
                return string.Empty;
            }

            string[] formattedParameters = _keyValuePairs.Select(x => $"{x.Key}={x.Value}").ToArray();
            return $"?{string.Join("&", formattedParameters)}";
        }
    }
}
