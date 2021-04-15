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
    public interface IStopwordContext
    {
        IMongoCollection<Stopwords> StopwordsCollection { get; }
    }
}
