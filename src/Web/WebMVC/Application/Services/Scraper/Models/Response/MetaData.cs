using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebMVC.Application.Services.Scraper.Models.Response
{
    public class MetaData
    {
        [JsonPropertyName("metas")]
        public List<string> Metas { get; set; }

        [JsonPropertyName("metaOccurences")]
        public Dictionary<string, int> MetaOccurences { get; set; }
    }
}
