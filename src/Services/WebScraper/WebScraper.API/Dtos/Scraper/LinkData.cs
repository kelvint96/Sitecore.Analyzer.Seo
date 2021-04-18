using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.API.Dtos.Scraper
{
    public class LinkData
    {
        public List<string> Links { get; set; }
        public int LinkOccurences { get; set; }
    }
}
