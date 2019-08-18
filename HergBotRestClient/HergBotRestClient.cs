using HergBot.RestClient.Http;

namespace HergBot.RestClient
{
    public class HergBotRestClient
    {
        private IHttpClient _client;

        public HergBotRestClient(string authToken)
        {
            InitializeHttpClient(authToken);
        }

        public HttpResponse Get(string apiUrl)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            return getRequest.Send(HttpVerb.GET).Result;
        }

        public HttpResponse Get(string apiUrl, UniqueIdParameter uidParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            return getRequest.Send(HttpVerb.GET, uidParam).Result;
        }

        public HttpResponse Get(string apiUrl, QueryParameter queryParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            return getRequest.Send(HttpVerb.GET, queryParam).Result;
        }

        public HttpResponse Post(string apiUrl, UniqueIdParameter uidParam, JsonBodyParameter body)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            return getRequest.Send(HttpVerb.POST, uidParam, body).Result;
        }

        public HttpResponse Put(string apiUrl, JsonBodyParameter body)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            return getRequest.Send(HttpVerb.PUT, null, body).Result;
        }

        public HttpResponse Delete(string apiUrl, UniqueIdParameter uidParam)
        {
            HttpRequest getRequest = new HttpRequest(_client, apiUrl);
            return getRequest.Send(HttpVerb.DELETE, uidParam).Result;
        }

        private void InitializeHttpClient(string authToken)
        {
            _client = new HttpClientHandler();
            _client.SetBearerToken(authToken);
        }
    }
}
