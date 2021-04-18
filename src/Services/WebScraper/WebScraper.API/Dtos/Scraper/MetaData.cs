using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.API.Dtos.Scraper
{
    public class MetaData
    {
        public List<string> Metas { get; set; }
        public Dictionary<string, int> MetaOccurences { get; set; }
    }
}
