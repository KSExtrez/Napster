using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Napster.Domain.AggregatesModel.AlbumAggregate;
using Napster.Domain.AggregatesModel.ArtistAggregate;
using Napster.Domain.AggregatesModel.GenreAggregate;

namespace Napster.Infrastructure.DataAccess.Mongo
{
    public class NapsterContext
    {
        private readonly IMongoDatabase _database;

        public NapsterContext(IOptions<NapsterSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Album> Albums => _database.GetCollection<Album>("Albums");

        public IMongoCollection<Artist> Artists => _database.GetCollection<Artist>("Artists");

        public IMongoCollection<Genre> Genres => _database.GetCollection<Genre>("Genres");
    }
}
