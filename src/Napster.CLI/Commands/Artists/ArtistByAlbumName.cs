using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("album_name", Description = "Obtiene el artista por el nombre del album")]
    public class ArtistByAlbumName
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public ArtistByAlbumName(IArtistRepository artistRepository, IAlbumRepository genreRepository)
        {
            _artistRepository = artistRepository;
            _albumRepository = genreRepository;
        }
        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre del album: ");
            string value = Console.ReadLine() ?? "";
            var album = _albumRepository.GetAlbumByName(value).Result;
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
