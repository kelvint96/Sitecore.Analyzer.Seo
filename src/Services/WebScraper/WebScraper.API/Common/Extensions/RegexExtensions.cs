using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebScraper.API.Common.Extensions
{
    public static class RegexExtensions
    {
        public static Regex isWord = new Regex(@"\p{L}+");
        public static Regex isLink = new Regex(@"(http|ftp|https)://([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?");

        public static bool isMatchRegex(Regex regex, string text) => regex.IsMatch(text);
        public static List<string> listMatchingRegex(Regex regex, string text) => regex.Matches(text).Select(x => x.Value).ToList();
    }
}
