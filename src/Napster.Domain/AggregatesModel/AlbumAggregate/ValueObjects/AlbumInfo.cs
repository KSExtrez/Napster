namespace Napster.Domain.AggregatesModel.AlbumAggregate.ValueObjects
{
    public record class AlbumInfo
    {
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
        /// Creates a new <see cref="AlbumInfo"/> instance.
        /// </summary>
        /// <param name="imgUrl">Album image url.</param>
        /// <param name="releaseDate">Album release date.</param>
        /// <param name="label">Album label.</param>
        public AlbumInfo(Uri imgUrl, DateOnly releaseDate, string label)
        {
            ImgUrl = imgUrl;
            ReleaseDate = releaseDate;
            Label = label;
        }
    }
}
