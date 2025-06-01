namespace Caneko.Domain.Entities
{
    public abstract class BaseEntity
    {
        public required string Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
