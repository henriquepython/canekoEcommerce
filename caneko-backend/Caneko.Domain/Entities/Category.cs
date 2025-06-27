using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities
{
    public class Category : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
