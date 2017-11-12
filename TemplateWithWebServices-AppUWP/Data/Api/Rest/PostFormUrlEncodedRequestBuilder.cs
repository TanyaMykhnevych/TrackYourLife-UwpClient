﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace UwpClientApp.Data.Api.Rest
{
    public class PostFormUrlEncodedRequestBuilder
    {
        private readonly UrlRequestBuilder _requestBuilder;
        private readonly IList<KeyValuePair<string, string>> _params;

        public PostFormUrlEncodedRequestBuilder(UrlRequestBuilder requestBuilder)
        {
            _requestBuilder = requestBuilder;
            _params = new List<KeyValuePair<string, string>>();
        }

        public PostFormUrlEncodedRequestBuilder Param(string key, string value)
        {
            _params.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public Task<T> PostAsync<T>()
        {
            Request request = _requestBuilder.CreateRequest();
            return request.PostFormUrlEncoded<T>(_params);
        }
    }
}
