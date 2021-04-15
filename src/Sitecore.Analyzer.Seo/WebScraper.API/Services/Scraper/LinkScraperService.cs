using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebScraper.API.Entities;
using WebScraper.API.Interfaces.Scraper;

namespace WebScraper.API.Services.Scraper
{
    public class LinkScraperService : ILinkScraperService
    {
        public readonly HttpClient _httpClient;
        public LinkScraperService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ScrapedData> ScrapeData(string link)
        {
            _httpClient.BaseAddress = new Uri(link);
            var response = await _httpClient.GetAsync(link);
            var rawHtmlData = await response.Content.ReadAsStringAsync();
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(rawHtmlData);

            var scrapedData = new ScrapedData();
            scrapedData.BodyContent = pageDocument.DocumentNode.SelectSingleNode("//body").InnerText;

            pageDocument.DocumentNode.SelectNodes("//meta").ToList()
                .ForEach(x => scrapedData.MetaTags.Add(x.GetAttributeValue("content", string.Empty)));

            pageDocument.DocumentNode.SelectNodes("//a[@href]").ToList()
                .ForEach(x => scrapedData.Links.Add(x.GetAttributeValue("href", string.Empty)));

            return scrapedData;
        }



        public Task<Dictionary<string, int>> GetWordOccurences(string text)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetMetaTagOccurences(string text)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetExternalLinksOccurences(string text)
        {
            throw new NotImplementedException();
        }

    }
}
