using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Artists
{
    [Command("track_id", Description = "Obtiene el artista por el id de la cancion")]
    public class ArtistByTrackId
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public ArtistByTrackId(IArtistRepository artistRepository, IAlbumRepository genreRepository)
        {
            _artistRepository = artistRepository;
            _albumRepository = genreRepository;
        }
        public void OnExecute(CommandLineApplication app)
        {
            Console.Write("Ingresa el id de la cancion: ");
            string value = Console.ReadLine() ?? "";
            var track = _albumRepository.GetTrackById(value).Result;
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
