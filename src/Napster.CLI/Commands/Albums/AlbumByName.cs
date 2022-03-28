using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Albums
{
    [Command("nombre", Description = "Obtiene el album por nombre")]
    public class AlbumByName
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumByName(IAlbumRepository albumRepository)
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
            string jsonString = JsonSerializer.Serialize(album);
            Console.WriteLine(jsonString);
        }
    }
}
