using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HergBot.RestClient.Http
{
    public class HttpClientHandler : IHttpClient
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _client.DeleteAsync(url);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return await _client.PutAsync(url, content);
        }

        public void SetBearerToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public string GetBearerToken()
        {
            if (_client.DefaultRequestHeaders.Authorization == null)
            {
                return null;
            }

            return _client.DefaultRequestHeaders.Authorization.Parameter;
        }
    }
}
