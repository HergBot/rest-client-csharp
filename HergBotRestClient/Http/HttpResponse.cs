using System.Net;

namespace HergBot.RestClient.Http
{
    /// <summary>
    /// A class that holds all useful information from an HTTP response.
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// The full request URL this response is from.
        /// </summary>
        public string RequestUrl { get; private set; }

        /// <summary>
        /// Whether the request was successful or not (Success is any 100, 200, or 300 status
        /// codes).
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// The status code returned by the request (Defaults to 500 if the request didn't
        /// even reach the server).
        /// </summary>
        public HttpStatusCode Status { get; private set; }

        /// <summary>
        /// The response body.
        /// </summary>
        public string Response { get; private set; }

        /// <summary>
        /// The HTTP verb used in the request.
        /// </summary>
        public HttpVerb Verb { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestUrl">The full request URL this response is from.</param>
        /// <param name="statusCode">The status code returned by the request.</param>
        /// <param name="response">The response body.</param>
        /// <param name="verb">The HTTP verb used in the request.</param>
        public HttpResponse(string requestUrl, HttpStatusCode statusCode, string response, HttpVerb verb)
        {
            RequestUrl = requestUrl;
            Success = IsRequestSuccessful(statusCode);
            Status = statusCode;
            Response = response;
            Verb = verb;
        }

        /// <summary>
        /// Determines whether the request was successful base on the status code received.
        /// Any 100, 200, or 300 status codes are considered successful.
        /// </summary>
        /// <param name="statusCode">The response status code.</param>
        /// <returns>True if the status code is 1xx, 2xx, or 3xx and false otherwise.</returns>
        private bool IsRequestSuccessful(HttpStatusCode statusCode)
        {
            // All 1xx, 2xx, and 3xx status codes (100-399) are considered successful
            int codeGroup = (int)statusCode / 100;
            return codeGroup == 1 || codeGroup == 2 || codeGroup == 3;
        }
    }
}
