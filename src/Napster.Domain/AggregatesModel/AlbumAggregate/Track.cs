using MongoDB.Bson.Serialization.Attributes;
using Napster.Domain.SeedWork;

namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public sealed class Track : Entity
    {
        /// <summary>
        /// Gets a genre description.
        /// </summary>
        [BsonElement("Id")]
        public string? TrackId { get; init; }

        /// <summary>
        /// Gets parent album id.
        /// </summary>
        public string AlbumId { get; init; }

        /// <summary>
        /// Gets a preview url.
        /// </summary>
        public Uri Preview { get; init; }

        /// <summary>
        /// Gets track duration.
        /// </summary>
        public uint Duration { get; init; }

        /// <summary>
        /// Gets a parent artist.
        /// </summary>
        public string ArtistId { get; init; }

        /// <summary>
        /// Gets an track related genres ids.
        /// </summary>
        public IEnumerable<string> GenreIds { get; init; }

        /// <summary>
        /// Creates a new <see cref="Track"/> instance.
        /// </summary>
        /// <param name="id">Track unique id.</param>
        /// <param name="name">Track name.</param>
        /// <param name="album">Track parent album.</param>
        /// <param name="preview">Track preview.</param>
        /// <param name="duration">Track duration.</param>
        /// <param name="artist">Track parent artist.</param>
        public Track(string id, string trackId, string name, string albumId, Uri preview, uint duration, string artistId, IEnumerable<string> genreIds)
            : base(id, name)
        {
            TrackId = trackId;
            AlbumId = albumId;
            Preview = preview;
            Duration = duration;
            ArtistId = artistId;
            GenreIds = genreIds;
        }
    }
}
