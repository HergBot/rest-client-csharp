using System.Collections.Generic;

namespace HergBot.RestClient.Http
{
    /// <summary>
    /// A class to manage key value pairs for passing data through HTTP requests.
    /// </summary>
    public class DataParameter
    {
        /// <summary>
        /// The raw list of key value pairs.
        /// </summary>
        protected Dictionary<string, string> _keyValuePairs;

        /// <summary>
        /// Constructor
        /// </summary>
        public DataParameter()
        {
            _keyValuePairs = new Dictionary<string, string>();
        }

        /// <summary>
        /// Adds a value to the key value pair list.
        /// </summary>
        /// <param name="key">A unique key.</param>
        /// <param name="value">The value to be paired to the key.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the key is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the key is already used.</exception>
        public void AddValue(string key, string value)
        {
            _keyValuePairs.Add(key, value);
        }

        /// <summary>
        /// Gets the value associated with a given key.
        /// </summary>
        /// <param name="key">The unique key to look up.</param>
        /// <returns>The string value if the key exists, null if it does not.</returns>
        public string GetValue(string key)
        {
            if (!_keyValuePairs.ContainsKey(key))
            {
                return null;
            }
            return _keyValuePairs[key];
        }

        /// <summary>
        /// Clears the key value pair list.
        /// </summary>
        public void ClearValues()
        {
            _keyValuePairs.Clear();
        }
    }
}
