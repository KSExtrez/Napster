using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("id", Description = "Obtiene el artista por id")]
    internal class ArtistById
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistById(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id del artista: ");
            string value = Console.ReadLine() ?? "";
            var artist = _artistRepository.GetArtistById(value).Result;
            string jsonString = JsonSerializer.Serialize(artist);
            Console.WriteLine(jsonString);
        }
    }
}
