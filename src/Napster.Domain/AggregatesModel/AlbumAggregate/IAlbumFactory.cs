using Napster.Domain.AggregatesModel.AlbumAggregate.ValueObjects;

namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public interface IAlbumFactory
    {
        Album CreateAlbum(string id, string name, AlbumInfo albumInfo, List<Track> tracks, List<string> genreIds);

        Track CreateTrack(string id, string name, string albumId, TrackInfo trackInfo, string artistId);
    }
}
