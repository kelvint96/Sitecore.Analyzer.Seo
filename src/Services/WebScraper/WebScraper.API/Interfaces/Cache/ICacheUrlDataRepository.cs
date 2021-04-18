using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Dtos.Scraper;

namespace WebScraper.API.Interfaces.Scraper
{
    public interface ICacheUrlDataRepository
    {
        Task<ScrapedData> GetSiteDataFromCache(string url);
        Task InsertSiteDataToCache(string url, ScrapedData siteData);
        Task RemoveSiteDataFromCache(string url);
    }
}
