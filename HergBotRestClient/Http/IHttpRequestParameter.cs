namespace HergBot.RestClient.Http
{
    /// <summary>
    /// An interface to allow different types of request parameters to be used in requests.
    /// </summary>
    public interface IHttpRequestParameter
    {
        /// <summary>
        /// Formats the request parameter based on the type.
        /// </summary>
        /// <returns>The formatted request parameter.</returns>
        string Format();
    }
}
