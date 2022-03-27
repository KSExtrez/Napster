namespace Napster.Domain.AggregatesModel.ArtistAggregate
{
    public interface IArtistFactory
    {
        /// <summary>
        /// Creates a new <see cref="Artist"/> instance.
        /// </summary>
        /// <returns>New Artist instance.</returns>
        Artist CreateArtist(string id, string name, Uri imgUrl, IEnumerable<string> genreIds);
    }
}
