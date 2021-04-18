using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebMVC.Application.Services.Scraper.Models.Response
{
    public class LinkData
    {
        [JsonPropertyName("links")]
        public List<string> Links { get; set; }

        [JsonPropertyName("linkOccurences")]
        public int LinkOccurences { get; set; }
    }
}
