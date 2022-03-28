using McMaster.Extensions.CommandLineUtils;

namespace Napster.CLI.Commands.Genre
{
    [Command("genre", Description = "Administrar generos y sub-generos")]
    [Subcommand(typeof(AllGenres))]
    [Subcommand(typeof(GenreByName))]
    [Subcommand(typeof(GenreById))]
    [Subcommand(typeof(ParentGenreById))]
    public class GenreCommand
    {
        public void OnExecute(CommandLineApplication app) => app.ShowHelp();
    }
}
