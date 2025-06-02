using Caneko.Domain.Entities;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        public bool Deleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required int StockId { get; set; }
        public required int CategoryId { get; set; }
        public string? ImagePrincipalUrl { get; set; }
        public Detail? Details { get; set; }
        public List<string> ImageSecondaryUrl { get; set; } = new List<string>();
        public bool IsHighlight { get; set; }
        public string[]? TypeColor { get; set; }
        public string[]? TypeUnits { get; set; }
        public string? SupplierSale { get; set; }
    }
}
