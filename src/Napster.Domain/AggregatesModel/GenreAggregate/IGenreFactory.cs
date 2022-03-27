namespace Napster.Domain.AggregatesModel.GenreAggregate
{
    public interface IGenreFactory
    {
        /// <summary>
        /// Creates a new <see cref="Genre"/> instance.
        /// </summary>
        /// <returns>New genre instance</returns>
        Genre CreateGenre(string id, string name, string? description, string parentGenreId);
    }
}
