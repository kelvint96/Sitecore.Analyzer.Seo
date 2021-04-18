using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.API.Dtos.Scraper
{
    public class BodyData
    {
        public string Body { get; set; }
        public Dictionary<string, int> BodyOccurence { get; set; }
    }
}
