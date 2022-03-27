namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public interface IAlbumRepository
    {
        /// <summary>
        /// Gets an album by id.
        /// </summary>
        /// <param name="id">Album unique id.</param>
        /// <returns>An album</returns>
        Album GetAlbumById(string id);

        /// <summary>
        /// Gets an album by track.
        /// </summary>
        /// <param name="id">Track unique id.</param>
        /// <returns>An album</returns>
        Album GetAlbumByTrackId(string id);

        /// <summary>
        /// Gets all albums.
        /// </summary>
        /// <returns>A collection of albums.</returns>
        IEnumerable<Album> GetAllAlbums();

        /// <summary>
        /// Gets an album by id.
        /// </summary>
        /// <param name="id">Album unique id.</param>
        /// <returns>A collection of albums.</returns>
        IEnumerable<Album> GetAlbumsByArtistId(string id);

        /// <summary>
        /// Gets a track by id.
        /// </summary>
        /// <param name="id">Track unique id.</param>
        /// <returns>A track.</returns>
        Track GetTrackById(string id);

        /// <summary>
        /// Get all tracks.
        /// </summary>
        /// <returns>A collection of tracks.</returns>
        IEnumerable<Track> GetAllTracks();

        /// <summary>
        /// Get track by Artist id
        /// </summary>
        /// <param name="artistId">An artist id.</param>
        /// <returns>A collection of tracks</returns>
        IEnumerable<Track> GetTrackByArtistId(string artistId);

        /// <summary>
        /// Get track by Album id
        /// </summary>
        /// <param name="albumId">An album id.</param>
        /// <returns>A collection of tracks</returns>
        IEnumerable<Track> GetTrackByAlbumId(string albumId);
    }
}
