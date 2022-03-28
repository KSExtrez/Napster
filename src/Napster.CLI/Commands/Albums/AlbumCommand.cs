using McMaster.Extensions.CommandLineUtils;

namespace Napster.CLI.Commands.Albums
{
    [Command("album", Description = "Administrador de albums")]
    public class AlbumCommand
    {
        public void OnExecute(CommandLineApplication app) => app.ShowHelp();
    }
}
