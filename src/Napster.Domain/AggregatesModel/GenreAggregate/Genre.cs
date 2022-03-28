using MongoDB.Bson.Serialization.Attributes;
using Napster.Domain.SeedWork;

namespace Napster.Domain.AggregatesModel.GenreAggregate
{
    public sealed class Genre : Entity
    {
        /// <summary>
        /// Gets a genre description.
        /// </summary>
        [BsonElement("Id")]
        public string? GenreId { get; init; }

        /// <summary>
        /// Gets a genre description.
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// Gets a parent genre id.
        /// </summary>
        public string ParentGenreId { get; init; }

        /// <summary>
        /// Creates a new <see cref="Genre"/> instance.
        /// </summary>
        /// <param name="id">Genre id.</param>
        /// <param name="name">Genre name.</param>
        /// <param name="description">Genre description.</param>
        /// <param name="parentGenreId">Genre parend id.</param>
        public Genre(string id, string genreId, string name, string? description, string parentGenreId)
            : base(id, name)
        {
            GenreId = genreId;
            Description = description;
            ParentGenreId = parentGenreId;
        }
    }
}
