using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.GenreAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Genre
{
    [Command("all", Description = "Obtiene todos los generos")]
    public class AllGenres
    {
        private readonly IGenreRepository _genreRepository;

        public AllGenres(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            var genres = _genreRepository.GetAllGenres().Result.Select(x => x.Name);
            string jsonString = JsonSerializer.Serialize(genres);
            Console.WriteLine(jsonString);
        }
    }
}
