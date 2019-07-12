using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
