using McMaster.Extensions.CommandLineUtils;

namespace Napster.CLI.Commands.Init
{
    [Command("init", Description = "Seed Data")]
    [Subcommand(typeof(LoadCommand))]
    [Subcommand(typeof(ReloadCommand))]
    public class InitCommand
    {
        public void OnExecute(CommandLineApplication app) => app.ShowHelp();
    }
}
