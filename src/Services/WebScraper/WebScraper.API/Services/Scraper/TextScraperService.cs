using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Common.Extensions;
using WebScraper.API.Dtos.Scraper;
using WebScraper.API.Entities;
using WebScraper.API.Interfaces.Scraper;

namespace WebScraper.API.Services.Scraper
{
    public class TextScraperService : BaseScraperService, ITextScraperService
    {
        public async Task<ScrapedData> ScrapeData(string text)
        {
            var scrapedData = new ScrapedData();
            if (string.IsNullOrEmpty(text))
            {
                scrapedData.BodyContent = text;


                var links = RegexExtensions.listMatchingRegex(RegexExtensions.isLink, text);

                foreach (var link in links)
                {
                    scrapedData.Links.Add(link);
                }
            }


            return scrapedData;
        }
    }
}
