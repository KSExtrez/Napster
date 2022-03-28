using MongoDB.Driver;
using Napster.Domain.AggregatesModel.ArtistAggregate;

namespace Napster.Infrastructure.DataAccess.Mongo.Repositories
{
    public sealed class ArtistRepository : IArtistRepository
    {
        private readonly NapsterContext _context;

        public ArtistRepository(NapsterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _context.Artists.Find(_ => true).ToListAsync();
        }

        public async Task<Artist?> GetArtistById(string artistId)
        {
            return await _context.Artists.Find(x => x.ArtistId == artistId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Artist>> GetArtistsByGenreId(string genreId)
        {
            return await _context.Artists.Find(x => x.GenreIds.Contains(genreId)).ToListAsync();
        }
    }
}
