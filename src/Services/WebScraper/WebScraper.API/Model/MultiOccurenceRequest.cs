using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Entities;

namespace WebScraper.API.Model
{
    public class MultiOccurenceRequest
    {
        public List<string> Text { get; set; }
        public List<Stopwords> Stopwords { get; set; }
    }
}
