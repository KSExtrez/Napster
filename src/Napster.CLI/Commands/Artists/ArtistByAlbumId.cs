using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("album_id", Description = "Obtiene el artista por el id del album")]
    public class ArtistByAlbumId
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public ArtistByAlbumId(IArtistRepository artistRepository, IAlbumRepository genreRepository)
        {
            _artistRepository = artistRepository;
            _albumRepository = genreRepository;
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

            var artists = _artistRepository.GetArtistById(album.ArtistId).Result;
            string jsonString = JsonSerializer.Serialize(artists);
            Console.WriteLine(jsonString);
        }
    }
}
