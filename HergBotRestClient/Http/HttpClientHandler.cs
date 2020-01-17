using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HergBot.RestClient.Http
{
    /// <summary>
    /// A class to interface with .NET's HTTP client for making web requests.
    /// </summary>
    public class HttpClientHandler : IHttpClient
    {
        /// <summary>
        /// The HTTP client object. It is reccomended by Microsoft to use only 1 static instance of this class.
        /// See: https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.8
        /// </summary>
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Wraps the DeleteAsync method.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <returns>The HTTP response information.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the URL is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the request was already sent by 
        /// the client instance.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails due to an underlying issue.</exception>
        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _client.DeleteAsync(url);
        }

        /// <summary>
        /// Wraps the GetAsync method.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <returns>The HTTP response information.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the URL is null.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails due to an underlying issue.</exception>
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        /// <summary>
        /// Wraps the PostAsync method.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <param name="content">The HTTP content (the body, etc)</param>
        /// <returns>The HTTP response information.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the URL is null.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails due to an underlying issue.</exception>
        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }

        /// <summary>
        /// Wraps the PutAsync method.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <param name="content">The HTTP content (the body, etc)</param>
        /// <returns>The HTTP response information.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the URL is null.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails due to an underlying issue.</exception>
        public async Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return await _client.PutAsync(url, content);
        }

        /// <summary>
        /// Sets the Authorization header with a bearer token.
        /// </summary>
        /// <param name="token">The bearer token to use.</param>
        public void SetBearerToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        /// <summary>
        /// Gets the current bearer token being used by the HTTP client.
        /// </summary>
        /// <returns>The current bearer token.</returns>
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
