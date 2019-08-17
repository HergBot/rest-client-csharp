using System.Collections.Generic;

namespace HergBot.RestClient.Http
{
    public class DataParameter
    {
        protected Dictionary<string, string> _keyValuePairs;

        public DataParameter()
        {
            _keyValuePairs = new Dictionary<string, string>();
        }

        public void AddValue(string key, string value)
        {
            _keyValuePairs.Add(key, value);
        }

        public string GetValue(string key)
        {
            if (!_keyValuePairs.ContainsKey(key))
            {
                return null;
            }
            return _keyValuePairs[key];
        }

        public void ClearValues()
        {
            _keyValuePairs.Clear();
        }
    }
}
