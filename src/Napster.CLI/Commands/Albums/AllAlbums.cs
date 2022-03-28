using McMaster.Extensions.CommandLineUtils;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using System.Text.Json;

namespace Napster.CLI.Commands.Albums
{
    [Command("all", Description = "Obtiene todos los albums")]
    internal class AllAlbums
    {
        private readonly IAlbumRepository _albumRepository;

        public AllAlbums(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void OnExecute(CommandLineApplication app)
        {
            var albums = _albumRepository.GetAllAlbums();
            string jsonString = JsonSerializer.Serialize(albums);
            Console.WriteLine(jsonString);
        }
    }
}
