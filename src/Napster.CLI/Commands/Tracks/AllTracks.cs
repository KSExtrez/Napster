using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Tracks
{
    [Command("all", Description = "Obtiene el todas las canciones")]
    public class AllTracks
    {
        private readonly IAlbumRepository _albumRepository;

        public AllTracks(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            var tracks = _albumRepository.GetAllTracks();
            string jsonString = JsonSerializer.Serialize(tracks);
            Console.WriteLine(jsonString);
        }
    }
}
