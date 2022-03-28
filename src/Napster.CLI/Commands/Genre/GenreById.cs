using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.GenreAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Genre
{
    [Command("id", Description = "Obtiene genero por Id")]
    internal class GenreById
    {
        private readonly IGenreRepository _genreRepository;

        public GenreById(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id del genero: ");
            string value = Console.ReadLine() ?? "";
            var genre = _genreRepository.GetGenreById(value).Result;

            string jsonString = JsonSerializer.Serialize(genre);
            Console.WriteLine(jsonString);
        }
    }
}
