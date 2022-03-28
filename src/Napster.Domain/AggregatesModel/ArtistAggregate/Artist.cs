using MongoDB.Bson.Serialization.Attributes;
using Napster.Domain.SeedWork;

namespace Napster.Domain.AggregatesModel.ArtistAggregate
{
    public sealed class Artist : Entity
    {
        /// <summary>
        /// Gets a genre description.
        /// </summary>
        [BsonElement("Id")]
        public string? ArtistId { get; init; }

        /// <summary>
        /// Gets an artist image url.
        /// </summary>
        public Uri ImgUrl { get; init; }

        /// <summary>
        /// Gets an artist related genres ids.
        /// </summary>
        public IEnumerable<string> GenreIds { get; init; }

        /// <summary>
        /// Creates a new <see cref="Artist"/> instance.
        /// </summary>
        /// <param name="id">Artist unique id.</param>
        /// <param name="name">Artist name.</param>
        /// <param name="imgUrl">Artist image url.</param>
        /// <param name="genres">Artist genres.</param>
        public Artist(string id, string artistId, string name, Uri imgUrl, IEnumerable<string> genreIds)
            : base(id, name)
        {
            ArtistId = artistId;
            ImgUrl = imgUrl;
            GenreIds = genreIds;
        }
    }
}
