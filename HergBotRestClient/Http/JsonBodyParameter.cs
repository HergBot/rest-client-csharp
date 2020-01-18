using Newtonsoft.Json;

namespace HergBot.RestClient.Http
{
    /// <summary>
    /// A class to format the body of an HTTP request in JSON.
    /// </summary>
    public class JsonBodyParameter : DataParameter, IHttpRequestParameter
    {
        /// <summary>
        /// Formats the key/value collection in JSON.
        /// </summary>
        /// <returns>The JSON string.</returns>
        public string Format()
        {
            return JsonConvert.SerializeObject(_keyValuePairs);
        }
    }
}
