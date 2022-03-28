namespace Napster.Domain.AggregatesModel.GenreAggregate
{
    public interface IGenreRepository
    {
        /// <summary>
        /// Gets an genre by id.
        /// </summary>
        /// <param name="genreId">An genre id.</param>
        /// <returns>An artist.</returns>
        Task<Genre?> GetGenreById(string genreId);

        /// <summary>
        /// Get all genres.
        /// </summary>
        /// <returns>A collection of genres.</returns>
        Task<IEnumerable<Genre>> GetAllGenres();

        /// <summary>
        /// Get all genres by parent genre id.
        /// </summary>
        /// <param name="genreId">A parent genre id.</param>
        /// <returns>A collection of genres.</returns>
        Task<IEnumerable<Genre>> GetGenresByParentGenreId(string parentGenreId);
    }
}
