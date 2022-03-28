using McMaster.Extensions.CommandLineUtils;

namespace Napster.CLI.Commands.Tracks
{
    [Command("track", Description = "Administraor de canciones")]
    [Subcommand(typeof(AllTracks))]
    [Subcommand(typeof(TrackById))]
    [Subcommand(typeof(TrackByName))]
    [Subcommand(typeof(TracksByAlbumId))]
    [Subcommand(typeof(TracksByAlbumName))]
    [Subcommand(typeof(TracksByArtistId))]
    [Subcommand(typeof(TracksByArtistName))]
    public class TrackCommand
    {
        public void OnExecute(CommandLineApplication app) => app.ShowHelp();
    }
}
