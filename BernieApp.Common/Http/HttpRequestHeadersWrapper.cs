using System;
using BernieApp.Common.Models;
using System.Net.Http;

namespace BernieApp.Common.Http
{
    public class HttpRequestHeadersWrapper : IHttpRequestHeaders
    {
        private HttpClient _httpClient;

        public HttpRequestHeadersWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Add(string name, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(name, value);
        }

        public void Clear()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }
    }
}
