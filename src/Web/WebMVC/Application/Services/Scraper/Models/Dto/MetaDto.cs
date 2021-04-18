using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Application.Services.Scraper.Models.Dto
{
    public class MetaDto
    {
        public List<string> Metas { get; set; }
        public List<OccurenceDto> OccurenceList { get; set; }
    }
}
