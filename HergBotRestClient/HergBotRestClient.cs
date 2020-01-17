using HergBot.RestClient.Http;

namespace HergBot.RestClient
{
    /// <summary>
    /// A class to wrap the functionality to communicate with a REST API or make web requests.
    /// </summary>
    public class HergBotRestClient : IRestClient
    {
        /// <summary>
        /// The HTTP Client interface to use under the hood.
        /// </summary>
        private IHttpClient _client;

        /// <summary>
        /// The bearer token to be sent in the Authorization header.
        /// </summary>
        private string _authToken;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authToken">The bearer token to be used for authorization.</param>
        public HergBotRestClient(string authToken)
        {
            _authToken = authToken;
            _client = new HttpClientHandler();
        }

        /// <summary>
        /// Performs a plain GET request.
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <returns>The HTTP Response information.</returns>
        public HttpResponse Get(string apiUrl)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            // The bearer token must be set every time because the client is static behind the scenes and will
            // mean tokens are overwritten by subsequent instances of this class or other IRestClient interfaces.
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.GET).Result;
        }

        /// <summary>
        /// Performs a GET request with a unique ID (i.e. www.url.com/items/1).
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="uidParam">The Unique ID (i.e. the thing after the /).</param>
        /// <returns>The HTTP Response information.</returns>
        public HttpResponse Get(string apiUrl, UniqueIdParameter uidParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.GET, uidParam).Result;
        }

        /// <summary>
        /// Performs a GET request with query parameters (i.e. www.url.com/items?some=value&other=value).
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="queryParam">The query parameters.</param>
        /// <returns>The HTTP Response information.</returns>
        public HttpResponse Get(string apiUrl, QueryParameter queryParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.GET, queryParam).Result;
        }

        /// <summary>
        /// Performs a POST request.
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="uidParam">The Unique ID (i.e. the thing after the /).</param>
        /// <param name="body">A JSON body with additional details.</param>
        /// <returns>The HTTP Response information.</returns>
        public HttpResponse Post(string apiUrl, UniqueIdParameter uidParam, JsonBodyParameter body)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.POST, uidParam, body).Result;
        }

        /// <summary>
        /// Performs a PUT request.
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="body">A JSON body with additional details.</param>
        /// <returns>The HTTP Response information.</returns>
        public HttpResponse Put(string apiUrl, JsonBodyParameter body)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.PUT, null, body).Result;
        }

        /// <summary>
        /// Performs a DELETE request.
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="uidParam">The Unique ID (i.e. the thing after the /).</param>
        /// <returns>The HTTP Response information.</returns>
        public HttpResponse Delete(string apiUrl, UniqueIdParameter uidParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.DELETE, uidParam).Result;
        }
    }
}
