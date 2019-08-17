using Newtonsoft.Json;

namespace HergBot.RestClient.Http
{
    public class JsonBodyParameter : DataParameter, IHttpRequestParameter
    {
        public string Format()
        {
            return JsonConvert.SerializeObject(_keyValuePairs);
        }
    }
}
