using Caneko.Domain.Entities;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductViewModel
    {
        public bool Deleted { get; set; }
        public DateOnly? CreateDate { get; set; }
        public DateOnly? UpdateDate { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string SequencialId { get; set; }  // sequencia do produto
        public required string StockId { get; set; }  // id do estoque(estoque, lote e preço)
        public required Category Category { get; set; }
        public ProductImages? Images { get; set; }
        public Detail? Details { get; set; }
    }
}
