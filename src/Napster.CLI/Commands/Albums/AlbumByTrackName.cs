using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Albums
{
    [Command("track_name", Description = "Obtiene el album por nombre de cancion")]
    public class AlbumByTrackName
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumByTrackName(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre de la cancion: ");
            string value = Console.ReadLine() ?? "";
            var album = _albumRepository.GetAlbumByTrackName(value).Result;
            if (album == null)
            {
                Console.WriteLine($"No se encontro el album con la cancion: {value}");
                return;
            }
            string jsonString = JsonSerializer.Serialize(album.Name);
            Console.WriteLine(jsonString);
        }
    }
}
