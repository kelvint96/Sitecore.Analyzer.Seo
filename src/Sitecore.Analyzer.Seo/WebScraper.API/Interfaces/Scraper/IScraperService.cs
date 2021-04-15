using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Entities;

namespace WebScraper.API.Interfaces.Scraper
{
    public interface IScraperService
    {
        Task<Dictionary<string, int>> GetWordOccurences(string text);
        Task<Dictionary<string, int>> GetMetaTagOccurences(string text);
        Task<Dictionary<string, int>> GetExternalLinksOccurences(string text);
    }
}
