using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebMVC.Application.Services.Stopword.Models.Response
{
    public class Stopword
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("stopword")]
        public string Name { get; set; }
        
        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}
