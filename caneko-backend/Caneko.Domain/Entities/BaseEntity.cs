using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Caneko.Domain.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("deleted")]
        public bool Deleted { get; set; }

        [BsonElement("createDate")]
        public DateOnly? CreateDate { get; set; }

        [BsonElement("updateDate")]
        public DateOnly? UpdateDate { get; set; }
    }
}
