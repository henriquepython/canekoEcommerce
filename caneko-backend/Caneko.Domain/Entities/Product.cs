namespace Caneko.Domain.Entities;

public class Product: BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required int StockId { get; set; }  // id do estoque(estoque, lote e preço)
    public required int CategoryId { get; set; }
    public string? ImagePrincipalUrl { get; set; }
    public Detail? Details { get; set; }
    public List<string> ImageSecondaryUrl { get; set; } = new List<string>();
    public bool IsHighlight { get; set; }  // Indica se o produto é destaque na loja
    public string[]? TypeColor { get; set; } // cores disponiveis
    public string[]? TypeUnits { get; set; } // tamanhos disponiveis 
    public string SupplierSale { get; set; } = "Caneko";
}
