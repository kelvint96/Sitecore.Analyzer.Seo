using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebMVC.Application.Services.Scraper.Models.Response
{
    public class ScrapedData
    {
        [JsonPropertyName("bodyContent")]
        public string BodyContent { get; set; }

        [JsonPropertyName("metaTags")]
        public List<string> MetaTags { get; set; }

        [JsonPropertyName("links")]
        public List<string> Links { get; set; }
    }
}
