using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using Napster.Domain.AggregatesModel.GenreAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("genre_id", Description = "Obtiene todos los artistas por el id del genero")]
    public class ArtistByGenreId
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IGenreRepository _genreRepository;

        public ArtistByGenreId(IArtistRepository artistRepository, IGenreRepository genreRepository)
        {
            _artistRepository = artistRepository;
            _genreRepository = genreRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id del genero: ");
            string value = Console.ReadLine() ?? "";
            var genre = _genreRepository.GetGenreById(value).Result;
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
