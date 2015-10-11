using BernieApp.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BernieApp.Common.Http
{
    public class BernieHttpClient : IBernieHttpClient
    {
        private IssuesClient _issuesClient;
        private NewsClient _newsClient;

        public BernieHttpClient(IHttpClient httpClient)
        {
            _newsClient = new NewsClient(httpClient);
            _issuesClient = new IssuesClient(httpClient);
        }

        public async Task<IEnumerable<HitDataItem<NewsArticle>>> GetNewsAsync()
        {
            return await _newsClient.GetAsync();
        }

        public async Task<IEnumerable<HitDataItem<Issue>>> GetIssuesAsync()
        {
            return await _issuesClient.GetAsync( );
        }

        public async Task<HitDataItem<NewsArticle>> GetNewsArticleAsync(string id)
        {
            return await _newsClient.GetByIdAsync(new List<UrlQueryParam>
            {
                new UrlQueryParam
                {
                    Field = "q",
                    Value = "_id:" + id
                }
            });
        }

        public void Dispose()
        {
            _issuesClient.Dispose();
            _newsClient.Dispose();
        }
    }
}
