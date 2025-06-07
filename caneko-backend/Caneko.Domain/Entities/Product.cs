namespace Caneko.Domain.Entities;

public class Product: BaseEntity
{
    public required string SequencialId { get; set; }  // sequencia do produto
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string StockId { get; set; }  // id do estoque(estoque, lote e preço)
    public required Category Category { get; set; }
    public ProductImages? Images { get; set; }
    public Detail? Details { get; set; }
}
