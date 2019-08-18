using System.Net.Http;
using System.Threading.Tasks;

namespace HergBot.RestClient.Http
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> DeleteAsync(string url);

        Task<HttpResponseMessage> GetAsync(string url);

        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);

        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);

        void SetBearerToken(string token);

        string GetBearerToken();
    }
}
