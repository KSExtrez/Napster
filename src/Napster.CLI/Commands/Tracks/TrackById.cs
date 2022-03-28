using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Tracks
{
    [Command("id", Description = "Obtiene la cancion por id")]
    public class TrackById
    {
        private readonly IAlbumRepository _albumRepository;

        public TrackById(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id de la cancion: ");
            string value = Console.ReadLine() ?? "";
            var track = _albumRepository.GetTrackById(value).Result;
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
