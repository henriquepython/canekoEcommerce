using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities
{
    public class Category : BaseEntity
    {
        [BsonElement("name")]
        public required string Name { get; set; }
    }
}
