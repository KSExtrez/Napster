using MongoDB.Driver;
using Napster.Domain.AggregatesModel.AlbumAggregate;

namespace Napster.Infrastructure.DataAccess.Mongo.Repositories
{
    public sealed class AlbumRepository : IAlbumRepository
    {
        private readonly NapsterContext _context;

        public AlbumRepository(NapsterContext context)
        {
            _context = context;
        }

        public async Task<Album?> GetAlbumById(string id)
        {
            return await _context.Albums.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Album?> GetAlbumByTrackId(string id)
        {
            return await _context.Albums.Find(x => x.Tracks.Any(x => x.AlbumId == id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Album>> GetAlbumsByArtistId(string id)
        {
            return await _context.Albums.Find(x => x.ArtistId == id).ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            var filter = Builders<Album>.Filter.Empty;
            return await _context.Albums.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            var albums = await GetAllAlbums();
            return albums.SelectMany(x => x.Tracks);
        }

        public async Task<IEnumerable<Track>> GetTrackByArtistId(string artistId)
        {
            var albums = await _context.Albums.Find(x => x.Tracks.Any(t => t.ArtistId == artistId)).ToListAsync();
            return albums.SelectMany(x => x.Tracks);
        }

        public async Task<Track?> GetTrackById(string id)
        {
            var album = await GetAlbumByTrackId(id);
            return album?.Tracks.First(x => x.Id == id);
        }
    }
}
