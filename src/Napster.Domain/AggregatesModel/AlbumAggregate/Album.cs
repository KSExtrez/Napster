using MongoDB.Bson.Serialization.Attributes;
using Napster.Domain.SeedWork;
using System.Text.Json.Serialization;

namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public sealed class Album : Entity
    {
        /// <summary>
        /// Gets a genre description.
        /// </summary>
        [BsonElement("Id")]
        public string AlbumId { get; init; }

        /// <summary>
        /// Gets an Album iamge url.
        /// </summary>
        [BsonElement("Img")]
        public Uri ImgUrl { get; init; }

        /// <summary>
        /// Gets an Album release date.
        /// </summary>
        public DateTime ReleaseDate { get; init; }

        /// <summary>
        /// Gets an Album label.
        /// </summary>
        public string Label { get; init; }

        /// <summary>
        /// Gets an artist parent id.
        /// </summary>
        public string ArtistId { get; init; }

        /// <summary>
        /// Gets an Album tracks.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<Track> Tracks { get; init; }

        /// <summary>
        /// Gets an Album related genres.
        /// </summary>
        public IReadOnlyList<string> GenreIds { get; init; }

        /// <summary>
        /// Creates a new <see cref="Album"/> instance.
        /// </summary>
        /// <param name="id">Album unique id.</param>
        /// <param name="name">Album name.</param>
        /// <param name="imgUrl">Album iamge url.</param>
        /// <param name="releaseDate">Album release date.</param>
        /// <param name="label">Album label.</param>
        /// <param name="tracks">Album tracks.</param>
        /// <param name="genres">Album related genres.</param>
        public Album(string id, string albumId, string name, Uri imgUrl, DateTime releaseDate, string label, string artistId, List<Track> tracks, List<string> genreIds)
            : base(id, name)
        {
            AlbumId = albumId;
            ImgUrl = imgUrl;
            ReleaseDate = releaseDate;
            Label = label;
            ArtistId = artistId;
            Tracks = tracks;
            GenreIds = genreIds;
        }
    }
}
