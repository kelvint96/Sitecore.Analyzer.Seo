using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.API.Entities
{
    public class CachedSiteData
    {
        public string Url { get; set; }
        public string Data { get; set; }
        public DateTime CachedTime { get; set; }
    }
}
