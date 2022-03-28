using McMaster.Extensions.CommandLineUtils;

namespace Napster.CLI.Commands.Tracks
{
    [Command("track", Description = "Administraor de canciones")]
    public class TrackCommand
    {
        public void OnExecute(CommandLineApplication app) => app.ShowHelp();
    }
}
