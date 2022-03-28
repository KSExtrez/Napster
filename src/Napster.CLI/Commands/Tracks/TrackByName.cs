using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Tracks
{
    [Command("name", Description = "Obtiene la cancion por nombre")]
    public class TrackByName
    {
        private readonly IAlbumRepository _albumRepository;

        public TrackByName(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre de la cancion: ");
            string value = Console.ReadLine() ?? "";
            var track = _albumRepository.GetTrackByName(value).Result;
            if (track == null)
            {
                Console.WriteLine($"No se encontro la cancion: {value}");
                return;
            }
            string jsonString = JsonSerializer.Serialize(track);
            Console.WriteLine(jsonString);
        }
    }
}
