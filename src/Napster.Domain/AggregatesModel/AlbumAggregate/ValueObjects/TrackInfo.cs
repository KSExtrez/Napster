namespace Napster.Domain.AggregatesModel.AlbumAggregate.ValueObjects
{
    public record class TrackInfo
    {
        /// <summary>
        /// Gets a preview url.
        /// </summary>
        public Uri Preview { get; init; }

        /// <summary>
        /// Gets track duration.
        /// </summary>
        public TimeOnly Duration { get; init; }

        /// <summary>
        /// Creates a new <see cref="TrackInfo"/> instance.
        /// </summary>
        /// <param name="preview"></param>
        /// <param name="duration"></param>
        public TrackInfo(Uri preview, TimeOnly duration)
        {
            Preview = preview;
            Duration = duration;
        }
    }
}
