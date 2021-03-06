using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebScraper.API.Common.Exceptions;
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
            Uri testUri;
            var isUrl = Uri.TryCreate(link, UriKind.Absolute, out testUri) && (testUri.Scheme == Uri.UriSchemeHttp || testUri.Scheme == Uri.UriSchemeHttps);
            if (!isUrl) throw new BadRequestException("An invalid Url is received.");

            var scrapedData = new ScrapedData();

            if (!string.IsNullOrEmpty(link))
            {
                _httpClient.BaseAddress = new Uri(link);
                var response = await _httpClient.GetAsync(link);
                var rawHtmlData = await response.Content.ReadAsStringAsync();
                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(rawHtmlData);

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
            }


            return scrapedData;
        }
    }
}
