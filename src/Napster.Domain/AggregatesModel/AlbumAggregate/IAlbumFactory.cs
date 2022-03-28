namespace Napster.Domain.AggregatesModel.AlbumAggregate
{
    public interface IAlbumFactory
    {
        Album CreateAlbum(string id, string name, Uri imgUrl, DateOnly releaseDate, string label, string artistId, List<Track> tracks, List<string> genreIds);

        Track CreateTrack(string id, string name, string albumId, Uri preview, TimeOnly duration, string artistId);
    }
}
