using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Interfaces.Stopwords;

namespace WebScraper.API.Repositories.Stopwords
{
    public class StopwordsRepository : IStopwordsRepository
    {
        public Task<Entities.Stopwords> CreateStopword(Entities.Stopwords stopword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStopwords()
        {
            throw new NotImplementedException();
        }

        public Task<List<Entities.Stopwords>> GetStopwordByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entities.Stopwords>> GetStopwords()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStopwords(Entities.Stopwords stopword)
        {
            throw new NotImplementedException();
        }
    }
}
