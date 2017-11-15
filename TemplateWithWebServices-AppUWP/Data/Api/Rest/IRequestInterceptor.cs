using System.Net.Http;

namespace UwpClientApp.Data.Api.Rest
{
    public interface IRequestInterceptor
    {
        void RemoveInterceptorIfExist(string key);

        void Intercept(HttpClient httpClient);
    }
}
