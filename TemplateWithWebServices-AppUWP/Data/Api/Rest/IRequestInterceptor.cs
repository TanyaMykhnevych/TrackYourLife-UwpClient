using System.Net.Http;

namespace UwpClientApp.Data.Api.Rest
{
    public interface IRequestInterceptor
    {
        void Intercept(HttpClient httpClient);
    }
}
