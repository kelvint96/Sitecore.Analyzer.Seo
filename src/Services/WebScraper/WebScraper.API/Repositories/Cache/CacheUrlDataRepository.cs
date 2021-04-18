using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebScraper.API.Dtos.Scraper;
using WebScraper.API.Interfaces.Scraper;

namespace WebScraper.API.Repositories.Cache
{
    public class CacheUrlDataRepository : ICacheUrlDataRepository
    {
        public readonly IDistributedCache _redisCache;

        public CacheUrlDataRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<ScrapedData> GetSiteDataFromCache(string url)
        {
            var siteData = await _redisCache.GetStringAsync(url);

            if (String.IsNullOrEmpty(siteData))
                return null;

            return JsonSerializer.Deserialize<ScrapedData>(siteData);
        }

        public async Task InsertSiteDataToCache(string url, ScrapedData siteData)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            var serializedData = JsonSerializer.Serialize(siteData);
            await _redisCache.SetStringAsync(url, serializedData, options);
        }

        public async Task RemoveSiteDataFromCache(string url)
        {
            await _redisCache.RemoveAsync(url);
        }
    }
}
