using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Domain.Enums
{
    public class ScrapeTypes : Enumeration
    {
        public static ScrapeTypes Text = new ScrapeTypes(1, "Text");
        public static ScrapeTypes Link = new ScrapeTypes(1, "Url");
        public ScrapeTypes(short id, string name) : base(id, name)
        {
        }

        public static IEnumerable<ScrapeTypes> List() => new[] { Text, Link };

        public static ScrapeTypes FromName(string name)
        {
            var state = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Possible values for ScrapeTypes: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
