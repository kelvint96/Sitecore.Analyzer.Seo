using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Entities;
using WebScraper.API.Interfaces.Scraper;

namespace WebScraper.API.Services.Scraper
{
    public class TextScraperService : ITextScraperService
    {
        public Task<Dictionary<string, int>> GetExternalLinksOccurences(string text)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetMetaTagOccurences(string text)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetWordOccurences(string text)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetWordOccurences(List<string> textList, List<Stopwords> stopwords)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetWordOccurences(string text, List<Stopwords> stopwords)
        {
            throw new NotImplementedException();
        }

        public Task<ScrapedData> ScrapeData(string text)
        {
            throw new NotImplementedException();
        }
    }
}
