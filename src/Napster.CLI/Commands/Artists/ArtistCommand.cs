using McMaster.Extensions.CommandLineUtils;

namespace Napster.CLI.Commands.Artists
{
    [Command("artist", Description = "Administrador de artistas")]
    [Subcommand(typeof(AllArtists))]
    [Subcommand(typeof(ArtistByAlbumId))]
    [Subcommand(typeof(ArtistByAlbumName))]
    [Subcommand(typeof(ArtistByGenreId))]
    [Subcommand(typeof(ArtistByGenreName))]
    [Subcommand(typeof(ArtistById))]
    [Subcommand(typeof(ArtistByName))]
    [Subcommand(typeof(ArtistByTrackId))]
    [Subcommand(typeof(ArtistByTrackName))]
    public class ArtistCommand
    {
        public void OnExecute(CommandLineApplication app) => app.ShowHelp();
    }
}
