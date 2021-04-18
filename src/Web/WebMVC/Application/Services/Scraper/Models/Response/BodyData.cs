using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebMVC.Application.Services.Scraper.Models.Response
{
    public class BodyData
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("bodyOccurence")]
        public Dictionary<string, int> BodyOccurence { get; set; }
    }
}
