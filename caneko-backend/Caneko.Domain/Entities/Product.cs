using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

[BsonIgnoreExtraElements]
public class Product : BaseEntity
{
    public Product(bool deleted = false, DateOnly? createDate = null, DateOnly? updateDate = null)
        : base(deleted, createDate, updateDate)
    {
    }

    public Product(bool deleted = false, DateOnly? createDate = null, DateOnly? updateDate = null, string? sequencialId = null)
        : base(deleted, createDate, updateDate)
    {
        SetSequencialId(sequencialId ?? string.Empty);
    }

    public Product()
    {
    }

    [BsonElement("sequencialId")]
    public string? SequencialId { get; private set; }

    [BsonElement("name")]
    public required string Name { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("stockId")]
    public string? StockId { get; set; }  // id do estoque(estoque, lote e preço)

    [BsonElement("categoryId")]
    public string? CategoryId { get; set; }

    [BsonElement("images")]
    public ProductImages? Images { get; set; }

    [BsonElement("details")]
    public Detail? Details { get; set; }
    
    public void SetSequencialId(string sequencialId)
    {
        if (string.IsNullOrWhiteSpace(sequencialId))
            throw new ArgumentException("SequencialId cannot be null or empty.", nameof(sequencialId));

        SequencialId = sequencialId;
    }
}
