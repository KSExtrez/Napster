using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.GenreAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Genre
{
    [Command("parent", Description = "Obtiene generos por genero padre")]
    public class ParentGenreById
    {
        private readonly IGenreRepository _genreRepository;

        public ParentGenreById(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id del genero padre: ");
            string value = Console.ReadLine() ?? "";
            var genres = _genreRepository.GetGenresByParentGenreId(value).Result;

            string jsonString = JsonSerializer.Serialize(genres);
            Console.WriteLine(jsonString);
        }
    }
}
