using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Tracks
{
    [Command("album_name", Description = "Obtiene la cancion por nombre del album")]
    internal class TracksByAlbumName
    {
        private readonly IAlbumRepository _albumRepository;

        public TracksByAlbumName(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre del album: ");
            string value = Console.ReadLine() ?? "";
            var album = _albumRepository.GetAlbumByName(value).Result;
            if (album == null)
            {
                Console.WriteLine($"No se encontro el album: {value}");
                return;
            }
            string jsonString = JsonSerializer.Serialize(album.Tracks);
            Console.WriteLine(jsonString);
        }
    }
}
