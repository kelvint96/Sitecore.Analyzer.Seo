using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StopwordsEntity = WebScraper.API.Entities.Stopwords;

namespace WebScraper.API.Interfaces.Stopwords
{
    public interface IStopwordsRepository
    {
        Task<List<StopwordsEntity>> GetStopwords();
        Task<List<StopwordsEntity>> GetStopwordByName(string name);
        Task<bool> UpdateStopwords(StopwordsEntity stopword);
        Task<bool> DeleteStopwords();
        Task<StopwordsEntity> CreateStopword(StopwordsEntity stopword);
    }
}
