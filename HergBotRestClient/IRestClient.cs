using HergBot.RestClient.Http;

namespace HergBot.RestClient
{
    public interface IRestClient
    {
        HttpResponse Get(string apiUrl);

        HttpResponse Get(string apiUrl, UniqueIdParameter uidParam);

        HttpResponse Get(string apiUrl, QueryParameter queryParam);

        HttpResponse Post(string apiUrl, UniqueIdParameter uidParam, JsonBodyParameter body);

        HttpResponse Put(string apiUrl, JsonBodyParameter body);

        HttpResponse Delete(string apiUrl, UniqueIdParameter uidParam);
    }
}
