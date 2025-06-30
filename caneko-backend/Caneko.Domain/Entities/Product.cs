using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities;

[BsonIgnoreExtraElements]
public class Product: BaseEntity
{
    [BsonElement("sequencialId")]
    public required string SequencialId { get; set; }  // sequencia do produto

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
}
