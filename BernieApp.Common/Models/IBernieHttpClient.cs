﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BernieApp.Common.Models
{
    public interface IBernieHttpClient : IDisposable
    {
        Task<IEnumerable<HitDataItem<NewsArticle>>> GetNewsAsync();

        Task<HitDataItem<NewsArticle>> GetNewsArticleAsync(string id);

        Task<IEnumerable<HitDataItem<Issue>>> GetIssuesAsync();
    }
}
