using Caneko.Domain.Entities;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }


        //stock
        public decimal FactoryPrice { get; set; }
        public int Quantity { get; set; }
        public decimal ProfitMarginPercent { get; set; }
        public required string Lot { get; set; }
        //stock

        public Category Category { get; set; }
        public ProductImages? Images { get; set; }
        public Detail? Details { get; set; }
    }
}
