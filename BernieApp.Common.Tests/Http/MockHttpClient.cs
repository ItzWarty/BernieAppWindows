using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BernieApp.Common.Models;
using System.Net;

namespace BernieApp.Common.Tests.Http
{
    public class MockHttpClient : IHttpClient
    {
        private MockHttpRequestHeaders _mockHttpRequestHeaders;

        public MockHttpClient()
        {
            _mockHttpRequestHeaders = new MockHttpRequestHeaders();
        }

        public IHttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return _mockHttpRequestHeaders;
            }
        }

        public HttpStatusCode ReturnStatusCode { get; set; }

        public void Dispose()
        {
            
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return await Task.Run<HttpResponseMessage>(() => 
            {
                return new HttpResponseMessage(ReturnStatusCode);
            });
        }
    }
}
