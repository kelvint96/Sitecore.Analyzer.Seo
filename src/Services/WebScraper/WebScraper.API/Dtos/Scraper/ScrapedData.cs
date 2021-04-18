using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.API.Dtos.Scraper
{
    public class ScrapedData
    {
        public string BodyContent { get; set; }
        public List<string> MetaTags { get; set; } = new List<string>();
        public List<string> Links { get; set; } = new List<string>();
    }
}
