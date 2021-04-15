using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Entities;

namespace WebScraper.API.Data
{
    public class StopwordContextSeed
    {
        public static void SeedData(IMongoCollection<Stopwords> stopwordsCollection)
        {
            bool isStopwordExists = stopwordsCollection.Find(p => true).Any();

            if (!isStopwordExists)
            {
                stopwordsCollection.InsertMany(GetPreconfiguredStopwords());
            }
        }

        private static IEnumerable<Stopwords> GetPreconfiguredStopwords()
        {
            return new List<Stopwords>()
            {
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "a", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "about", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "above", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "across", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "after", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "afterwards", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "again", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "against", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "all", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "almost", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "alone", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "along", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "already", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "also", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "although", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "always", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "am", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "among", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "amongst", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "amount", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "an", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "and", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "another", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "any", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "anyhow", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "anyone", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "anything", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "anyway", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "anywhere", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "are", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "around", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "as", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "at", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "back", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "be", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "became", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "because", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "become", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "becomes", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "becoming", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "been", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "before", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "beforehand", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "behind", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "being", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "below", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "beside", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "besides", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "between", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "beyond", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "bill", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "both", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "bottom", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "but", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "by", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "call", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "can", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "cannot", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "cant", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "co", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "computer", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "con", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "could", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "couldnt", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "cry", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "de", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "describe", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "detail", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "do", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "done", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "down", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "due", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "during", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "each", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "eg", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "eight", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "either", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "eleven", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "else", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "elsewhere", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "empty", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "enough", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "etc", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "even", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "ever", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "every", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "everyone", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "everything", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "everywhere", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "except", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "few", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "fifteen", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "fify", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "fill", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "find", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "fire", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "first", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "five", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "for", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "former", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "formerly", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "forty", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "found", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "four", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "from", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "front", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "full", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "further", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "get", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "give", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "go", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "had", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "has", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "have", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "hence", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "he", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "her", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "here", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "this", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "un", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "we", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "would", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "yet", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "where", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "whenever", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "you", Active = true },
                new(){Id = ObjectId.GenerateNewId().ToString(), Stopword = "your", Active = true },

            };
        }
    }
}
