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

        public async Task<Album?> GetAlbumById(string albumId)
        {
            return await _context.Albums.Find(x => x.AlbumId == albumId).FirstOrDefaultAsync();
        }

        public async Task<Album?> GetAlbumByTrackId(string trackId)
        {
            return await _context.Albums.Find(x => x.Tracks.Any(x => x.TrackId == trackId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Album>> GetAlbumsByArtistId(string artistId)
        {
            return await _context.Albums.Find(x => x.ArtistId == artistId).ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetAlbumsByGenreId(string genreId)
        {
            return await _context.Albums.Find(x => x.GenreIds.Contains(genreId)).ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            return await _context.Albums.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            var albums = await GetAllAlbums();
            return albums.SelectMany(x => x.Tracks);
        }

        public async Task<IEnumerable<Track>> GetTrackByArtistId(string artistId)
        {
            var albums = await _context.Albums.Find(x => x.Tracks.Any(t => t.ArtistId == artistId)).ToListAsync();
            return albums.SelectMany(x => x.Tracks).Where(x => x.ArtistId == artistId);
        }

        public async Task<Track?> GetTrackById(string trackId)
        {
            var album = await GetAlbumByTrackId(trackId);
            return album?.Tracks.First(x => x.TrackId == trackId);
        }
    }
}
