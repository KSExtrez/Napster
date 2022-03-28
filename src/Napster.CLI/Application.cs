using McMaster.Extensions.CommandLineUtils;
using Napster.CLI.Commands.Albums;
using Napster.CLI.Commands.Artists;
using Napster.CLI.Commands.Genre;
using Napster.CLI.Commands.Init;
using Napster.CLI.Commands.Tracks;

namespace Napster.CLI
{
    [Command(Description = Description)]
    [Subcommand(typeof(InitCommand))]
    [Subcommand(typeof(GenreCommand))]
    [Subcommand(typeof(ArtistCommand))]
    [Subcommand(typeof(AlbumCommand))]
    [Subcommand(typeof(TrackCommand))]
    public class Application
    {
        public const string Description = "This tool is a command line interface allowing " +
                                          "manage Napster scraped data.";

        public void OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
        }
    }
}
