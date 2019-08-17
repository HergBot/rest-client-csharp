using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HergBot.RestClient.Http
{
    public class QueryParameter : DataParameter, IHttpRequestParameter
    {
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
