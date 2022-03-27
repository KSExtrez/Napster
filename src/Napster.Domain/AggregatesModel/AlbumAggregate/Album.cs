using Napster.Domain.AggregatesModel.AlbumAggregate.ValueObjects;
using Napster.Domain.SeedWork;

namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public sealed class Album : Entity
    {
        /// <summary>
        /// Gets an album information.
        /// </summary>
        public AlbumInfo AlbumInfo { get; init; }

        /// <summary>
        /// Gets an Album tracks.
        /// </summary>
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
        public Album(string id, string name, AlbumInfo albumInfo, List<Track> tracks, List<string> genreIds)
            : base(id, name)
        {
            AlbumInfo = albumInfo;
            Tracks = tracks;
            GenreIds = genreIds;
        }
    }
}
