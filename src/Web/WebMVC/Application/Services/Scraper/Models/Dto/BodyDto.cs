using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Application.Services.Scraper.Models.Dto
{
    public class BodyDto
    {
        public string Body { get; set; }
        public List<OccurenceDto> OccurenceList { get; set; }
        
    }


}
