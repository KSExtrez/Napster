using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.GenreAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Genre
{
    [Command("name", Description = "Obtiene genero por nombre")]
    public class GenreByName
    {
        private readonly IGenreRepository _genreRepository;

        public GenreByName(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre del genero: ");
            string value = Console.ReadLine() ?? "";
            var genre = _genreRepository.GetGenreByName(value).Result;

            string jsonString = JsonSerializer.Serialize(genre);
            Console.WriteLine(jsonString);
        }
    }
}
