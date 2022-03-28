using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Albums
{
    [Command("id", Description = "Obtiene el album por id")]
    public class AlbumById
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumById(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id del album: ");
            string value = Console.ReadLine() ?? "";
            var album = _albumRepository.GetAlbumById(value).Result;
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
