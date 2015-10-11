using BernieApp.Common.Models;

namespace BernieApp.Common.Http
{
    public class NewsClient : ES4BSClient<NewsQueryResponse, NewsArticle>
    {
        public NewsClient(IHttpClient httpClient) : base(httpClient, Endpoints.SitesEN, "article_type:News")
        {

        }
    }
}
