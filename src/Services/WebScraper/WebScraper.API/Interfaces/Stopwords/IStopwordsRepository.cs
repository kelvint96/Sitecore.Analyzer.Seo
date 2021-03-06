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
        Task<StopwordsEntity> GetStopwordById(string id);
        Task<bool> UpdateStopwords(StopwordsEntity stopword);
        Task<bool> DeleteStopwords(string id);
        Task CreateStopword(StopwordsEntity stopword);
    }
}
