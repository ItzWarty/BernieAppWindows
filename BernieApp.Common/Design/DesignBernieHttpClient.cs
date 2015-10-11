﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BernieApp.Common.Models;

namespace BernieApp.Common.Design
{
    public class DesignBernieHttpClient : IBernieHttpClient
    {
        public void Dispose()
        {
            
        }

        public Task<IEnumerable<HitDataItem<Issue>>> GetIssuesAsync()
        {
            return null;
        }

        public Task<HitDataItem<NewsArticle>> GetNewsArticleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HitDataItem<NewsArticle>>> GetNewsAsync()
        {
            return null;
        }
    }
}
