namespace Napster.Domain.AggregatesModel.ArtistAggregate
{
    public interface IArtistRepository
    {
        /// <summary>
        /// Gets an artist by id.
        /// </summary>
        /// <param name="artistId">An artist id.</param>
        /// <returns>An artist.</returns>
        Artist GetArtistById(string artistId);

        /// <summary>
        /// Get all artist.
        /// </summary>
        /// <returns>A collection of artists.</returns>
        IEnumerable<Artist> GetAllArtists();

        /// <summary>
        /// Get all artist by genre id.
        /// </summary>
        /// <param name="genreId">A genre id.</param>
        /// <returns>A collection of artists.</returns>
        IEnumerable<Artist> GetArtistsByGenreId(string genreId);
    }
}
