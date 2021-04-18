using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Common.Extensions;
using WebScraper.API.Entities;
using WebScraper.API.Interfaces.Scraper;

namespace WebScraper.API.Services.Scraper
{
    public class BaseScraperService : IScraperService
    {
        public Dictionary<string, int> GetWordOccurences(List<string> textList, List<Stopwords> stopwords)
        {
            Dictionary<string, int> occurenceDictionary = new Dictionary<string, int>();
            foreach (var text in textList)
            {
                var occurence = GetWordOccurences(text, stopwords);
                occurenceDictionary = (from e in occurenceDictionary.Concat(occurence)
                                       group e by e.Key into g
                                       select new { Name = g.Key, Count = g.Sum(kvp => kvp.Value) })
              .ToDictionary(item => item.Name, item => item.Count);
            }

            return occurenceDictionary;
        }

        public Dictionary<string, int> GetWordOccurences(string text, List<Stopwords> stopwords)
        {
            Dictionary<string, int> occurenceDictionary = new Dictionary<string, int>();
            var wordList = RegexExtensions.listMatchingRegex(RegexExtensions.isWord, text);

            foreach (var word in wordList)
            {
                var searchWord = word.ToLower().Trim();

                if (!stopwords
                    .Select(x => x.Stopword)
                    .Contains(searchWord))
                {
                    if (!occurenceDictionary.ContainsKey(searchWord))
                    {
                        occurenceDictionary.Add(searchWord, 1);
                    }
                    else
                    {
                        occurenceDictionary[searchWord] += 1;
                    }
                }
            }

            return occurenceDictionary;

        }
    }
}
