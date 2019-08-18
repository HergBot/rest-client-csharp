using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HergBot.RestClient.Http
{
    public class HttpRequest
    {
        private IHttpClient _httpClient;

        private string _requestUrl;

        public HttpRequest(IHttpClient client, string url)
        {
            _httpClient = client;
            _requestUrl = url;
        }

        public async Task<HttpResponse> Send(HttpVerb verb, IHttpRequestParameter urlParameter = null, IHttpRequestParameter bodyParameter = null)
        {
            string fullRequestUrl = $"{_requestUrl}{ConstructParameterString(urlParameter)}";
            HttpContent content = new StringContent(ConstructParameterString(bodyParameter));
            HttpResponseMessage responseMessage = null;

            switch (verb)
            {
                case HttpVerb.DELETE:
                    responseMessage = await _httpClient.DeleteAsync(fullRequestUrl);
                    break;
                case HttpVerb.GET:
                    responseMessage = await _httpClient.GetAsync(fullRequestUrl);
                    break;
                case HttpVerb.POST:
                    responseMessage = await _httpClient.PostAsync(fullRequestUrl, content);
                    break;
                case HttpVerb.PUT:
                    responseMessage = await _httpClient.PutAsync(fullRequestUrl, content);
                    break;
                default:
                    throw new NotImplementedException($"HTTP Verb not implemented: {verb.ToString()}");
            }

            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            return new HttpResponse(
                fullRequestUrl,
                responseMessage.StatusCode,
                responseBody,
                verb
            );
        }

        private string ConstructParameterString(IHttpRequestParameter parameter)
        {
            if (parameter == null)
            {
                return string.Empty;
            }
            return parameter.Format();
        }
    }
}
