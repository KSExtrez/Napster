namespace Napster.Infrastructure.DataAccess.Mongo
{
    public sealed class NapsterSettings
    {
        /// <summary>
        /// Gets or sets a connection string.
        /// </summary>
        public string ConnectionString { get; set; } = null!;

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string DatabaseName { get; set; } = null!;
    }
}