using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace UwpClientApp.Data.Api.Rest
{
    public class RequestInterceptorBase : IRequestInterceptor
    {
        protected readonly List<KeyValuePair<string, string>> _queryItems;

        public RequestInterceptorBase(params KeyValuePair<string, string>[] queryItems)
        {
            _queryItems = queryItems.ToList();
        }

        public virtual void Intercept(HttpClient httpClient)
        {
            foreach (var queryItem in _queryItems)
            {
                httpClient.DefaultRequestHeaders.Add(queryItem.Key, queryItem.Value);
            }
        }

        public void AddInterceptor(KeyValuePair<string, string> interceptor)
        {
            _queryItems.Add(interceptor);
        }
    }
}
