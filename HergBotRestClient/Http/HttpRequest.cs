using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HergBot.RestClient.Http
{
    public class HttpRequest
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private static string _currentBearerToken;

        private string _requestUrl;

        public HttpRequest(string bearerToken, string url)
        {
            SetBearerToken(bearerToken);
            _requestUrl = url;
        }

        public async Task<HttpResponse> Send(HttpVerb verb, IHttpRequestParameter urlParameter = null, IHttpRequestParameter bodyParameter = null)
        {
            string fullRequestUrl = $"{_requestUrl}{ConstructParameterString(urlParameter)}";
            HttpContent content = new StringContent(ConstructParameterString(urlParameter));
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

        private void SetBearerToken(string bearerToken)
        {
            if (_currentBearerToken != bearerToken)
            {
                _currentBearerToken = bearerToken;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }
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
