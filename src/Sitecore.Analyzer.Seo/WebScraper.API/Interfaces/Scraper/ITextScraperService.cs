using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Entities;

namespace WebScraper.API.Interfaces.Scraper
{
    public interface ITextScraperService : IScraperService
    {
        Task<ScrapedData> ScrapeData(string text);
    }
}
