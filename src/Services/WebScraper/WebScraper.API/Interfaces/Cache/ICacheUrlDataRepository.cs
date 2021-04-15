using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Entities;

namespace WebScraper.API.Interfaces.Scraper
{
    public interface ICacheUrlDataRepository
    {
        Task<CachedSiteData> GetSiteDataFromCache(string url);
        Task InsertSiteDataToCache(CachedSiteData siteData);
        Task RemoveSiteDataFromCache(string url);
    }
}
