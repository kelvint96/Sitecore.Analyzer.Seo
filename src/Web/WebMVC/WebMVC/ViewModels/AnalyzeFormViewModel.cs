﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.ViewModels
{
    public class AnalyzeFormViewModel
    {
        [Required]
        public string Text { get; set; }
        public string ScrapeType { get; set; }
        public bool isBodySelected { get; set; }
        public bool isLinkSelected { get; set; }
        public bool isMetaSelected { get; set; }
    }
}
