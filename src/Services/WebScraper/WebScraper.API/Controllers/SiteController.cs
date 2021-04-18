using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebScraper.API.Dtos.Scraper;
using WebScraper.API.Interfaces.Scraper;
using WebScraper.API.Interfaces.Stopwords;

namespace WebScraper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapeController : ControllerBase
    {
        private readonly ILinkScraperService _linkScraperService;
        private readonly ITextScraperService _textScraperService;
        private readonly ICacheUrlDataRepository _cache;
        private readonly IStopwordsRepository _stopwordsRepository;

        public ScrapeController(ILinkScraperService linkScraperService, ICacheUrlDataRepository cache, IStopwordsRepository stopwordsRepository, ITextScraperService textScraperService)
        {
            _linkScraperService = linkScraperService ?? throw new ArgumentNullException(nameof(linkScraperService));
            _textScraperService = textScraperService ?? throw new ArgumentNullException(nameof(textScraperService));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _stopwordsRepository = stopwordsRepository ?? throw new ArgumentNullException(nameof(stopwordsRepository));
        }

        /// <summary>
        /// Gets the body content of site.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost("Url/Body")]
        [ProducesResponseType(typeof(BodyData), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<BodyData>> GetBodyData([Required][FromBody] ScrapeRequest request)
        {
            var scrapedData = await CheckForScrapedDataExistsInCacheAsync(request.Text);
            var stopwords = await _stopwordsRepository.GetStopwords();
            var bodyData = new BodyData
            {
                Body = scrapedData.BodyContent,
                BodyOccurence = _linkScraperService.GetWordOccurences(scrapedData.BodyContent, stopwords)
            };

            return Ok(bodyData);
        }

        /// <summary>
        /// Gets the metatags of the site
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost("Url/Meta")]
        [ProducesResponseType(typeof(MetaData), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<MetaData>> GetMetaData([Required][FromBody] ScrapeRequest request)
        {
            var scrapedData = await CheckForScrapedDataExistsInCacheAsync(request.Text);
            var stopwords = await _stopwordsRepository.GetStopwords();

            var metaData = new MetaData
            {
                Metas = scrapedData.MetaTags,
                MetaOccurences = _linkScraperService.GetWordOccurences(scrapedData.MetaTags, stopwords)
            };

            return Ok(metaData);
        }

        /// <summary>
        /// Gets the links on the site
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost("Url/Link")]
        [ProducesResponseType(typeof(LinkData), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<LinkData>> GetLinks([Required][FromBody] ScrapeRequest request)
        {
            var scrapedData = await CheckForScrapedDataExistsInCacheAsync(request.Text);

            var linksData = new LinkData
            {
                Links = scrapedData.Links,
                LinkOccurences = scrapedData.Links.Count()
            };

            return Ok(linksData);
        }

        /// <summary>
        /// Gets the body content of text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost("Text/Body")]
        [ProducesResponseType(typeof(BodyData), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<BodyData>> GetTextBodyData([Required][FromBody] ScrapeRequest request)
        {
            var stopwords = await _stopwordsRepository.GetStopwords();
            var bodyData = new BodyData
            {
                Body = request.Text,
                BodyOccurence = _textScraperService.GetWordOccurences(request.Text, stopwords)
            };

            return Ok(bodyData);
        }

        /// <summary>
        /// Gets the links on the text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost("Text/Link")]
        [ProducesResponseType(typeof(LinkData), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<LinkData>> GetTextLinks([Required][FromBody] ScrapeRequest request)
        {
            var scrapedData = await _textScraperService.ScrapeData(request.Text);

            var linksData = new LinkData
            {
                Links = scrapedData.Links,
                LinkOccurences = scrapedData.Links.Count()
            };

            return Ok(linksData);
        }

        private async Task<ScrapedData> CheckForScrapedDataExistsInCacheAsync(string text)
        {
            ScrapedData scrapedData = await _cache.GetSiteDataFromCache(text);
            if (scrapedData is null)
            {
                scrapedData = await _linkScraperService.ScrapeData(text);

                await _cache.InsertSiteDataToCache(text, scrapedData);
            }
            return scrapedData;
        }
    }
}
