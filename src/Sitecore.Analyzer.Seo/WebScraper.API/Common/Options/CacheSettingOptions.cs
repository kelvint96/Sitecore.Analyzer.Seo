using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.API.Common.Options
{
    public class CacheSettingOptions
    {
        public const string CacheSettings = "CacheSettings";

        public string ConnectionString { get; set; }
    }
}
