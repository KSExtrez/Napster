using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("name", Description = "Obtiene el artista por nombre")]
    internal class ArtistByName
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistByName(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre del artista: ");
            string value = Console.ReadLine() ?? "";
            var artists = _artistRepository.GetArtistByName(value).Result;
            string jsonString = JsonSerializer.Serialize(artists);
            Console.WriteLine(jsonString);
        }
    }
}
