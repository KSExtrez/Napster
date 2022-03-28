using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.AlbumAggregate.ValueObjects;

namespace Napster.Infrastructure.DataAccess.Mongo.Factories
{
    internal class AlbumFactory : IAlbumFactory
    {
        public Album CreateAlbum(string id, string name, Uri imgUrl, DateOnly releaseDate, string label, string artistId, List<Track> tracks, List<string> genreIds)
        {
            return new Album(id, name, new AlbumInfo(imgUrl, releaseDate, label), artistId, tracks, genreIds);
        }

        public Track CreateTrack(string id, string name, string albumId, Uri preview, TimeOnly duration, string artistId)
        {
            return new Track(id, name, albumId, new TrackInfo(preview, duration), artistId);
        }
    }
}
