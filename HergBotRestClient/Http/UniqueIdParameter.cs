using System;

namespace HergBot.RestClient.Http
{
    public class UniqueIdParameter : IHttpRequestParameter
    {
        private string _uniqueId;

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

        public string Format()
        {
            return $"/{_uniqueId}";
        }
    }
}
