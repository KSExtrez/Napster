using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("track_name", Description = "Obtiene el artista por el nombre de la cancion")]
    public class ArtistByTrackName
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public ArtistByTrackName(IArtistRepository artistRepository, IAlbumRepository genreRepository)
        {
            _artistRepository = artistRepository;
            _albumRepository = genreRepository;
        }
        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el nombre de la cancion: ");
            string value = Console.ReadLine() ?? "";
            var track = _albumRepository.GetTrackByName(value).Result;
            if (track == null)
            {
                Console.WriteLine($"No se encontro el album: {value}");
                return;
            }

            var artists = _artistRepository.GetArtistById(track.ArtistId).Result;
            string jsonString = JsonSerializer.Serialize(artists);
            Console.WriteLine(jsonString);
        }
    }
}
