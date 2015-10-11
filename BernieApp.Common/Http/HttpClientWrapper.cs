using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BernieApp.Common.Models;

namespace BernieApp.Common.Http
{
    public class HttpClientWrapper : IHttpClient, IDisposable
    {
        private HttpClient _httpClient;
        private HttpRequestHeadersWrapper _requestHeaders;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
            _requestHeaders = new HttpRequestHeadersWrapper(_httpClient);
        }

        public IHttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return _requestHeaders;
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return await _httpClient.GetAsync(uri);
        }
    }
}
