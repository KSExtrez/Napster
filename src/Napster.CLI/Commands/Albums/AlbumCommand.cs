using McMaster.Extensions.CommandLineUtils;

namespace Napster.CLI.Commands.Albums
{
    [Command("album", Description = "Administrador de albums")]
    [Subcommand(typeof(AllAlbums))]
    [Subcommand(typeof(AlbumById))]
    [Subcommand(typeof(AlbumByName))]
    [Subcommand(typeof(AlbumsByArtistId))]
    [Subcommand(typeof(AlbumsByArtistName))]
    [Subcommand(typeof(AlbumByTrackId))]
    [Subcommand(typeof(AlbumByTrackName))]
    public class AlbumCommand
    {
        public void OnExecute(CommandLineApplication app) => app.ShowHelp();
    }
}
