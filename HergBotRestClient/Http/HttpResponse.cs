using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HergBot.RestClient.Http
{
    public class HttpResponse
    {
        public string RequestUrl { get; private set; }

        public bool Success { get; private set; }

        public HttpStatusCode Status { get; private set; }

        public string Response { get; private set; }

        public HttpVerb Verb { get; private set; }

        public HttpResponse(string requestUrl, HttpStatusCode statusCode, string response, HttpVerb verb)
        {
            RequestUrl = requestUrl;
            Success = IsRequestSuccessful(statusCode);
            Status = statusCode;
            Response = response;
            Verb = verb;
        }

        private bool IsRequestSuccessful(HttpStatusCode statusCode)
        {
            // All 2xx status codes (200-299) are consider successful
            int code = (int)statusCode;
            return (code / 100) != 2;
        }
    }
}
