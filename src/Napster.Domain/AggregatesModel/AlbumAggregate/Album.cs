namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public sealed class Album
    {
        /// <summary>
        /// Gets an Album unique id.
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// Gets an Album name.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets an Album iamge url.
        /// </summary>
        public Uri ImgUrl { get; init; }

        /// <summary>
        /// Gets an Album release date.
        /// </summary>
        public DateOnly ReleaseDate { get; init; }

        /// <summary>
        /// Gets an Album label.
        /// </summary>
        public string Label { get; init; }

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
        public Album(string id, string name, Uri imgUrl, DateOnly releaseDate, string label, List<Track> tracks, List<string> genreIds)
        {
            Id = id;
            Name = name;
            ImgUrl = imgUrl;
            ReleaseDate = releaseDate;
            Label = label;
            Tracks = tracks;
            GenreIds = genreIds;
        }
    }
}
