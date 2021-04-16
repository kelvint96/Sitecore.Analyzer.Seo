using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.API.Data;
using MongoDB.Driver;
using WebScraper.API.Interfaces.Stopwords;

namespace WebScraper.API.Repositories.Stopwords
{
    public class StopwordsRepository : IStopwordsRepository
    {
        private readonly IStopwordContext _context;

        public StopwordsRepository(IStopwordContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateStopword(Entities.Stopwords stopword)
        {
            await _context.StopwordsCollection.InsertOneAsync(stopword);
        }

        public async Task<bool> DeleteStopwords(string id)
        {
            FilterDefinition<Entities.Stopwords> filter = Builders<Entities.Stopwords>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .StopwordsCollection
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Entities.Stopwords> GetStopwordById(string id)
        {
            FilterDefinition<Entities.Stopwords> filter = Builders<Entities.Stopwords>.Filter.Eq(p => p.Id, id);

            return await _context
                            .StopwordsCollection
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task<List<Entities.Stopwords>> GetStopwords()
        {
            return await _context
                .StopwordsCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task<bool> UpdateStopwords(Entities.Stopwords stopword)
        {
            var updateResult = await _context
                .StopwordsCollection
                .ReplaceOneAsync(filter: g => g.Id == stopword.Id, replacement: stopword);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
