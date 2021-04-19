using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Domain.Enums;

namespace WebMVC.ViewModels
{
    public class AnalyzeFormViewModel
    {
        [Required]
        public string Text { get; set; }
        public string ScrapeType { get; set; } = ScrapeTypes.Text.Name;
        public bool isBodySelected { get; set; } = true;
        public bool isLinkSelected { get; set; } = true;
        public bool isMetaSelected { get; set; }
    }
}
