using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("all", Description = "Obtiene todos los artistas")]
    public class AllArtists
    {
        private readonly IArtistRepository _artistRepository;

        public AllArtists(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            var genres = _artistRepository.GetAllArtists().Result;
            string jsonString = JsonSerializer.Serialize(genres.Select(x => x.Name));
            Console.WriteLine(jsonString);
        }
    }
}
