using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Albums
{
    [Command("artist_name", Description = "Obtiene el album por id de artista")]
    public class AlbumsByArtistName
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;

        public AlbumsByArtistName(IAlbumRepository albumRepository, IArtistRepository artistRepository)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre del artista: ");
            string value = Console.ReadLine() ?? "";
            var artist = _artistRepository.GetArtistByName(value).Result;
            if (artist == null)
            {
                Console.WriteLine($"No se encontro el artista: {value}");
                return;
            }

            var albums = _albumRepository.GetAlbumsByArtistId(artist.ArtistId);
            string jsonString = JsonSerializer.Serialize(albums);
            Console.WriteLine(jsonString);
        }
    }
}
