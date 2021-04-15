using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Common.Options;
using WebScraper.API.Entities;

namespace WebScraper.API.Data
{
    public class StopwordContext : IStopwordContext
    {
        public StopwordContext(IOptions<DatabaseSettingOptions> options)
        {
            var dbSettings = options.Value;
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            StopwordsCollection = database.GetCollection<Stopwords>(dbSettings.CollectionName);

            StopwordContextSeed.SeedData(StopwordsCollection);
        }


        public IMongoCollection<Stopwords> StopwordsCollection { get; }
    }
}
