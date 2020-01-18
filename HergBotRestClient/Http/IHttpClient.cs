using System.Net.Http;
using System.Threading.Tasks;

namespace HergBot.RestClient.Http
{
    /// <summary>
    /// An interface to allow different HTTP clients to be used internally.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Wraps the DeleteAsync method.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <returns>The HTTP response information.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the URL is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the request was already sent by 
        /// the client instance.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails due to an underlying issue.</exception>
        Task<HttpResponseMessage> DeleteAsync(string url);

        /// <summary>
        /// Wraps the GetAsync method.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <returns>The HTTP response information.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the URL is null.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails due to an underlying issue.</exception>
        Task<HttpResponseMessage> GetAsync(string url);

        /// <summary>
        /// Wraps the PostAsync method.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <param name="content">The HTTP content (the body, etc)</param>
        /// <returns>The HTTP response information.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the URL is null.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails due to an underlying issue.</exception>
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);

        /// <summary>
        /// Wraps the PutAsync method.
        /// </summary>
        /// <param name="url">The URL to send the request to.</param>
        /// <param name="content">The HTTP content (the body, etc)</param>
        /// <returns>The HTTP response information.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the URL is null.</exception>
        /// <exception cref="HttpRequestException">Thrown when the request fails due to an underlying issue.</exception>
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);

        /// <summary>
        /// Sets the Authorization header with a bearer token.
        /// </summary>
        /// <param name="token">The bearer token to use.</param>
        void SetBearerToken(string token);

        /// <summary>
        /// Gets the current bearer token being used by the HTTP client.
        /// </summary>
        /// <returns>The current bearer token.</returns>
        string GetBearerToken();
    }
}
