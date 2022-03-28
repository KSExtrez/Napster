using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Albums
{
    [Command("artist_id", Description = "Obtiene el album por id de artista")]
    public class AlbumsByArtistId
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumsByArtistId(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id del artista: ");
            string value = Console.ReadLine() ?? "";
            var albums = _albumRepository.GetAlbumsByArtistId(value).Result;
            if (albums == null)
            {
                Console.WriteLine($"No se encontro el album con la cancion: {value}");
                return;
            }
            string jsonString = JsonSerializer.Serialize(albums);
            Console.WriteLine(jsonString);
        }
    }
}
