using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebScraper.API.Entities;
using WebScraper.API.Interfaces.Scraper;
using WebScraper.API.Model;

namespace WebScraper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ILinkScraperService _linkScraperService;

        public SiteController(ILinkScraperService linkScraperService)
        {
            _linkScraperService = linkScraperService ?? throw new ArgumentNullException(nameof(linkScraperService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ScrapedData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ScrapedData>> GetScrapedData(string text, string scrapeType)
        {
            if (scrapeType.Equals("link"))
            {
                return Ok(await _linkScraperService.ScrapeData(text));
            }

            return BadRequest("Unsupported 'scrapeType'.");
        }

        [HttpPost("Occurence")]
        [ProducesResponseType(typeof(Dictionary<string, int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Dictionary<string, int>>> GetOccurence(OccurenceRequest request)
        {

            var result = _linkScraperService.GetWordOccurences(request.Text, request.Stopwords);

            return Ok(result);
        }

        [HttpPost("MultiOccurence")]
        [ProducesResponseType(typeof(Dictionary<string, int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Dictionary<string, int>>> GetMultiOccurence(MultiOccurenceRequest request)
        {

            var result = _linkScraperService.GetWordOccurences(request.Text, request.Stopwords);

            return Ok(result);
        }
    }
}
