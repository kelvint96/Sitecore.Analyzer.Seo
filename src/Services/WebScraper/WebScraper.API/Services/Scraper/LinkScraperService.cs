using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebScraper.API.Common.Extensions;
using WebScraper.API.Dtos.Scraper;
using WebScraper.API.Entities;
using WebScraper.API.Interfaces.Scraper;

namespace WebScraper.API.Services.Scraper
{
    public class LinkScraperService : BaseScraperService, ILinkScraperService
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
                .ForEach(x =>
                {
                    var metaContent = x.GetAttributeValue("content", string.Empty);

                    if (!string.IsNullOrWhiteSpace(metaContent)) scrapedData.MetaTags.Add(metaContent);
                });

            pageDocument.DocumentNode.SelectNodes("//a[@href]").ToList()
                .ForEach(x =>
                {
                    var href = x.GetAttributeValue("href", string.Empty);
                    Uri Uri;
                    var isExternalLink = Uri.TryCreate(href, UriKind.Absolute, out Uri) && (Uri.Scheme == Uri.UriSchemeHttp || Uri.Scheme == Uri.UriSchemeHttps);

                    if (isExternalLink) scrapedData.Links.Add(href);
                });

            return scrapedData;
        }
    }
}
