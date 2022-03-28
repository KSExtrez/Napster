using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Tracks
{
    [Command("artist_name", Description = "Obtiene las canciones por id de artista")]
    internal class TracksByArtistName
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;

        public TracksByArtistName(IAlbumRepository albumRepository, IArtistRepository artistRepository)
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

            var tracks = _albumRepository.GetTrackByArtistId(artist.ArtistId).Result;
            string jsonString = JsonSerializer.Serialize(tracks);
            Console.WriteLine(jsonString);
        }
    }
}
