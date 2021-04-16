using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Entities;
using StopwordsEntity = WebScraper.API.Entities.Stopwords;

namespace WebScraper.API.Interfaces.Scraper
{
    public interface IScraperService
    {
        Dictionary<string, int> GetWordOccurences(List<string> textList, List<StopwordsEntity> stopwords);
        Dictionary<string, int> GetWordOccurences(string text, List<StopwordsEntity> stopwords);
    }
}
