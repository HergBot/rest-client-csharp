using HergBot.RestClient.Http;

namespace HergBot.RestClient
{
    public class HergBotRestClient : IRestClient
    {
        private IHttpClient _client;

        private string _authToken;

        public HergBotRestClient(string authToken)
        {
            InitializeHttpClient();
        }

        public HttpResponse Get(string apiUrl)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            // The bearer token must be set every time because the client is static behind the scenes and will
            // mean tokens are overwritten by subsequent instances of this class or other IRestClient interfaces.
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.GET).Result;
        }

        public HttpResponse Get(string apiUrl, UniqueIdParameter uidParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.GET, uidParam).Result;
        }

        public HttpResponse Get(string apiUrl, QueryParameter queryParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.GET, queryParam).Result;
        }

        public HttpResponse Post(string apiUrl, UniqueIdParameter uidParam, JsonBodyParameter body)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.POST, uidParam, body).Result;
        }

        public HttpResponse Put(string apiUrl, JsonBodyParameter body)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.PUT, null, body).Result;
        }

        public HttpResponse Delete(string apiUrl, UniqueIdParameter uidParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            _client.SetBearerToken(_authToken);
            return getRequest.Send(HttpVerb.DELETE, uidParam).Result;
        }

        private void InitializeHttpClient()
        {
            _client = new HttpClientHandler();
        }
    }
}
