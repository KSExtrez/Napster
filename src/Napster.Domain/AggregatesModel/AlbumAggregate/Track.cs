namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public sealed class Track
    {
        /// <summary>
        /// Gets Track unique id.
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// Gets Track name.
        /// </summary>
        public string Name { get; init; }

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
        public TimeOnly Duration { get; init; }

        /// <summary>
        /// Gets a parent artist.
        /// </summary>
        public string ArtistId { get; init; }

        /// <summary>
        /// Creates a new <see cref="Track"/> instance.
        /// </summary>
        /// <param name="id">Track unique id.</param>
        /// <param name="name">Track name.</param>
        /// <param name="album">Track parent album.</param>
        /// <param name="preview">Track preview.</param>
        /// <param name="duration">Track duration.</param>
        /// <param name="artist">Track parent artist.</param>
        public Track(string id, string name, string albumId, Uri preview, TimeOnly duration, string artistId)
        {
            Id = id;
            Name = name;
            AlbumId = albumId;
            Preview = preview;
            Duration = duration;
            ArtistId = artistId;
        }
    }
}
