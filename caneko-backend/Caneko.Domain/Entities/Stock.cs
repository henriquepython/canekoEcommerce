using System.ComponentModel.DataAnnotations;

namespace Caneko.Domain.Entities
{
    public class Stock: BaseEntity
    {
        public required string ProductId { get; set; }
        public List<Lot>? Lot { get; set; } = new List<Lot>();
        //Preço de fabrica
        [MinLength(0)]
        public decimal FactoryPrice { get; set; }
        //margem de lucro
        public decimal ProfitMargin => ProfitMarginPercent / 100;
        //margem de lucro em porcentagem
        public decimal ProfitMarginPercent { get; set; }
        //Preço de venda
        public decimal SalePrice => FactoryPrice + (FactoryPrice * ProfitMargin);
        //Quantidade
        [MinLength(0)]
        public int QuantityTotal => Lot?.Count > 0 ? Lot.Sum(l => l?.Quantity ?? 0) : 0;
    }
}
