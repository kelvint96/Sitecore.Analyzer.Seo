using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebScraper.API.Entities;
using WebScraper.API.Interfaces.Scraper;

namespace WebScraper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        private readonly ILinkScraperService _linkScraperService;

        public ScraperController(ILinkScraperService linkScraperService)
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

            return BadRequest();
        }
    }
}
