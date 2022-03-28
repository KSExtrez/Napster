using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Napster.Domain.SeedWork
{
    public class Entity
    {
        /// <summary>
        /// Gets an entity unique id.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; }

        /// <summary>
        /// Gets an Album name.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Creates a new <see cref="Entity"/> instance.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <param name="name">Entity name.</param>
        public Entity(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
