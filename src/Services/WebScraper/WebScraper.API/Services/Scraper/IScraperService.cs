using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Entities;

namespace WebScraper.API.Services
{
    public interface IScraperService
    {
        Task<ScrapedData> GetScrapedData(string text);
    }
}
