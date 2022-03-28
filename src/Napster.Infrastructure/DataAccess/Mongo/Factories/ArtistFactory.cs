using Napster.Domain.AggregatesModel.ArtistAggregate;

namespace Napster.Infrastructure.DataAccess.Mongo.Factories
{
    internal class ArtistFactory : IArtistFactory
    {
        public Artist CreateArtist(string id, string name, Uri imgUrl, IEnumerable<string> genreIds)
        {
            return new Artist(id, name, imgUrl, genreIds);
        }
    }
}
