using System;
using System.Collections.Generic;
using System.Text;

namespace HergBot.RestClient.Http
{
    public class UniqueIdParameter : IHttpRequestParameter
    {
        private string _uniqueId;

        public UniqueIdParameter(string uid)
        {
            _uniqueId = uid;
        }

        public string Format()
        {
            return $"/{_uniqueId}";
        }
    }
}
