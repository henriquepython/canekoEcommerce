using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Caneko.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity(bool deleted = false, DateOnly? createDate = null, DateOnly? updateDate = null)
        {
            Deleted = deleted;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }

        [BsonElement("deleted")]
        public bool Deleted { get; private set; }

        [BsonElement("createDate")]
        public DateOnly? CreateDate { get; private set; }

        [BsonElement("updateDate")]
        public DateOnly? UpdateDate { get; private set; }

        public void SetDeleted(bool deleted)
        {
            Deleted = deleted;
        }

        public void SetCreateDate(DateOnly createDate)
        {
            CreateDate = createDate;
        }

        public void SetUpdateDate(DateOnly updateDate)
        {
            UpdateDate = updateDate;
        }
    }
}
