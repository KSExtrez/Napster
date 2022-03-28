using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using Napster.Domain.AggregatesModel.GenreAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("genre_name", Description = "Obtiene todos los artistas por el nombre del genero")]
    public class ArtistByGenreName
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IGenreRepository _genreRepository;

        public ArtistByGenreName(IArtistRepository artistRepository, IGenreRepository genreRepository)
        {
            _artistRepository = artistRepository;
            _genreRepository = genreRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre del genero: ");
            string value = Console.ReadLine() ?? "";
            var genre = _genreRepository.GetGenreByName(value).Result;

            if (genre == null)
            {
                Console.WriteLine($"No se encontro el genero: {value}");
                return;
            }

            var artists = _artistRepository.GetArtistsByGenreId(genre.GenreId).Result;
            string jsonString = JsonSerializer.Serialize(artists.Select(x => x.Name));
            Console.WriteLine(jsonString);
        }
    }
}
