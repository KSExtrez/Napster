namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public interface IAlbumRepository
    {
        /// <summary>
        /// Gets an album by id.
        /// </summary>
        /// <param name="id">Album unique id.</param>
        /// <returns>An album</returns>
        Task<Album?> GetAlbumById(string albumId);

        /// <summary>
        /// Gets an album by name.
        /// </summary>
        /// <param name="name">Album name.</param>
        /// <returns>An album</returns>
        Task<Album?> GetAlbumByName(string name);

        /// <summary>
        /// Gets an album by track.
        /// </summary>
        /// <param name="id">Track unique id.</param>
        /// <returns>An album</returns>
        Task<Album?> GetAlbumByTrackId(string trackId);

        /// <summary>
        /// Gets an album by track name.
        /// </summary>
        /// <param name="name">Track name.</param>
        /// <returns>An album</returns>
        Task<Album?> GetAlbumByTrackName(string name);

        /// <summary>
        /// Gets all albums.
        /// </summary>
        /// <returns>A collection of albums.</returns>
        Task<IEnumerable<Album>> GetAllAlbums();

        /// <summary>
        /// Gets an album by artist id.
        /// </summary>
        /// <param name="id">Artist id.</param>
        /// <returns>A collection of albums.</returns>
        Task<IEnumerable<Album>> GetAlbumsByArtistId(string artistId);

        /// <summary>
        /// Gets an album by genre id.
        /// </summary>
        /// <param name="id">Genre id.</param>
        /// <returns>A collection of albums.</returns>
        Task<IEnumerable<Album>> GetAlbumsByGenreId(string genreId);

        /// <summary>
        /// Gets a track by id.
        /// </summary>
        /// <param name="id">Track unique id.</param>
        /// <returns>A track.</returns>
        Task<Track?> GetTrackById(string trackId);

        /// <summary>
        /// Gets a track by name.
        /// </summary>
        /// <param name="name">Track name.</param>
        /// <returns>A track.</returns>
        Task<Track?> GetTrackByName(string name);

        /// <summary>
        /// Get all tracks.
        /// </summary>
        /// <returns>A collection of tracks.</returns>
        Task<IEnumerable<Track>> GetAllTracks();

        /// <summary>
        /// Get track by Artist id
        /// </summary>
        /// <param name="artistId">An artist id.</param>
        /// <returns>A collection of tracks</returns>
        Task<IEnumerable<Track>> GetTrackByArtistId(string artistId);
    }
}
