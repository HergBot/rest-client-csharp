using System;
using System.Collections.Generic;
using System.Text;

namespace HergBotRestClient
{
    public class DataParameter
    {
        private Dictionary<string, string> _keyValuePairs;

        public DataParameter()
        {
            _keyValuePairs = new Dictionary<string, string>();
        }
    }
}
