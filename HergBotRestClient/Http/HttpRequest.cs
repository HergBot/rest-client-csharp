using System;
using System.Net.Http;
using System.Threading.Tasks;

using HergBot.Utilities.ExceptionUtilities;

namespace HergBot.RestClient.Http
{
    /// <summary>
    /// A class that handles producing any type of HTTP request.
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// The client to use for the request.
        /// </summary>
        private IHttpClient _httpClient;

        /// <summary>
        /// The request URL.
        /// </summary>
        private string _requestUrl;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">The initialized HTTP client to use.</param>
        /// <param name="url">The base URL to send the request to.</param>
        public HttpRequest(IHttpClient client, string url)
        {
            _httpClient = client;
            _requestUrl = url;
        }

        /// <summary>
        /// Sends an HTTP request to the server and handles the response.
        /// </summary>
        /// <param name="verb">The HTTP verb to use for the request.</param>
        /// <param name="urlParameter">Any URL parameters to send.</param>
        /// <param name="bodyParameter">Any body parameters to send.</param>
        /// <returns>The HTTP Response information.</returns>
        /// <exception cref="System.NotImplementedException">Thrown when the HTTP verb given has not been
        /// implemented yet.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the request was already sent by 
        /// the client instance or the URI is invalid.</exception>
        public async Task<HttpResponse> Send(HttpVerb verb, IHttpRequestParameter urlParameter = null, IHttpRequestParameter bodyParameter = null)
        {
            string fullRequestUrl = $"{_requestUrl}{ConstructParameterString(urlParameter)}";
            HttpContent content = new StringContent(ConstructParameterString(bodyParameter));
            HttpResponseMessage responseMessage = null;
            try
            {
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
            }
            catch (HttpRequestException ex)
            {
                string error = ExceptionUtilities.GetAllExceptionMessages(ex);
                return new HttpResponse(
                    fullRequestUrl,
                    System.Net.HttpStatusCode.InternalServerError,
                    error,
                    verb
                );
            }
            
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            return new HttpResponse(
                fullRequestUrl,
                responseMessage.StatusCode,
                responseBody,
                verb
            );
        }

        /// <summary>
        /// Safely constructs the parameter string to gaurd against null values.
        /// </summary>
        /// <param name="parameter">The parameter object to construct.</param>
        /// <returns>The formated parameter string.</returns>
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
