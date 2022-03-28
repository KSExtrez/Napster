using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Tracks
{
    [Command("artist_id", Description = "Obtiene canciones por id de artista")]
    public class TracksByArtistId
    {
        private readonly IAlbumRepository _albumRepository;

        public TracksByArtistId(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id del artista: ");
            string value = Console.ReadLine() ?? "";
            var tracks = _albumRepository.GetTrackByArtistId(value).Result;
            string jsonString = JsonSerializer.Serialize(tracks);
            Console.WriteLine(jsonString);
        }
    }
}
