using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Albums
{
    [Command("track_id", Description = "Obtiene el album por id de cancion")]
    public class AlbumByTrackId
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumByTrackId(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id de la cancion: ");
            string value = Console.ReadLine() ?? "";
            var album = _albumRepository.GetAlbumByTrackId(value).Result;
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
