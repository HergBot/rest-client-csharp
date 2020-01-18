using System;

namespace HergBot.RestClient.Http
{
    /// <summary>
    /// A class to format URL parameters as a unique identifier in the URL.
    /// </summary>
    public class UniqueIdParameter : IHttpRequestParameter
    {
        /// <summary>
        /// The unique ID.
        /// </summary>
        private string _uniqueId;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uid">The unique ID.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if the unique ID is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown if the unique ID is an empty string or
        /// white space.</exception>
        public UniqueIdParameter(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
            {
                if (uid == null)
                {
                    throw new ArgumentNullException("Unique Id cannot be null");
                }
                throw new ArgumentException("Unique Id cannot be empty string or whitespace");
            }
            _uniqueId = uid;
        }

        /// <summary>
        /// Formats the unqiue ID as the last part of a URL.
        /// </summary>
        /// <returns>The formatted URL tail.</returns>
        public string Format()
        {
            return $"/{_uniqueId}";
        }
    }
}
