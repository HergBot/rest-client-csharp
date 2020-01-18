using HergBot.RestClient.Http;

namespace HergBot.RestClient
{
    /// <summary>
    /// An interface for implementing a basic REST Client.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Performs a plain GET request.
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <returns>The HTTP Response information.</returns>
        HttpResponse Get(string apiUrl);

        /// <summary>
        /// Performs a GET request with a unique ID (i.e. www.url.com/items/1).
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="uidParam">The Unique ID (i.e. the thing after the /).</param>
        /// <returns>The HTTP Response information.</returns>
        HttpResponse Get(string apiUrl, UniqueIdParameter uidParam);

        /// <summary>
        /// Performs a GET request with query parameters (i.e. www.url.com/items?some=value&other=value).
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="queryParam">The query parameters.</param>
        /// <returns>The HTTP Response information.</returns>
        HttpResponse Get(string apiUrl, QueryParameter queryParam);

        /// <summary>
        /// Performs a POST request.
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="uidParam">The Unique ID (i.e. the thing after the /).</param>
        /// <param name="body">A JSON body with additional details.</param>
        /// <returns>The HTTP Response information.</returns>
        HttpResponse Post(string apiUrl, UniqueIdParameter uidParam, JsonBodyParameter body);

        /// <summary>
        /// Performs a PUT request.
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="body">A JSON body with additional details.</param>
        /// <returns>The HTTP Response information.</returns>
        HttpResponse Put(string apiUrl, JsonBodyParameter body);

        /// <summary>
        /// Performs a DELETE request.
        /// </summary>
        /// <param name="apiUrl">The URL to perform the request on.</param>
        /// <param name="uidParam">The Unique ID (i.e. the thing after the /).</param>
        /// <returns>The HTTP Response information.</returns>
        HttpResponse Delete(string apiUrl, UniqueIdParameter uidParam);
    }
}
