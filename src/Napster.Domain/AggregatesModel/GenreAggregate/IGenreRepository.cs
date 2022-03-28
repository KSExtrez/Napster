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
        /// Gets a collection of genre by ids.
        /// </summary>
        /// <param name="genreIds">A collection of genre ids.</param>
        /// <returns>An artist.</returns>
        Task<IEnumerable<Genre>> GetGenreByIds(IEnumerable<string> genreIds);

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
