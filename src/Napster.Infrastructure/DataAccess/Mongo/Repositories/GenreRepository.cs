using MongoDB.Driver;
using Napster.Domain.AggregatesModel.GenreAggregate;

namespace Napster.Infrastructure.DataAccess.Mongo.Repositories
{
    public sealed class GenreRepository : IGenreRepository
    {
        private readonly NapsterContext _context;

        public GenreRepository(NapsterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _context.Genres.Find(_ => true).ToListAsync();
        }

        public async Task<Genre?> GetGenreById(string genreId)
        {
            return await _context.Genres.Find(x => x.GenreId == genreId).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Genre>> GetGenreByIds(IEnumerable<string> genreIds)
        {
            return await _context.Genres.Find(x => genreIds.Contains(x.GenreId)).ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresByParentGenreId(string parentGenreId)
        {
            return await _context.Genres.Find(x => x.ParentGenreId == parentGenreId).ToListAsync();
        }
    }
}
