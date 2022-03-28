using Napster.Domain.AggregatesModel.GenreAggregate;

namespace Napster.Infrastructure.DataAccess.Mongo.Factories
{
    public class GenreFactory : IGenreFactory
    {
        public Genre CreateGenre(string id, string name, string? description, string parentGenreId)
        {
            return new Genre(id, name, description, parentGenreId);
        }
    }
}
