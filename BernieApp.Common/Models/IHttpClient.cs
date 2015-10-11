using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BernieApp.Common.Models
{
    public interface IHttpClient : IDisposable
    {
        IHttpRequestHeaders DefaultRequestHeaders { get; }
        Task<HttpResponseMessage> GetAsync(Uri uri);
    }
}
