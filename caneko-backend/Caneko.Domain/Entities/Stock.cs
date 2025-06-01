namespace Caneko.Domain.Entities
{
    public class Stock: BaseEntity
    {
        public int ProductId { get; set; }
        public required string Lot { get; set; }
        //Preço de fabrica
        public decimal FactoryPrice { get; set; }
        //margem de lucro
        public decimal ProfitMargin => ProfitMargin / 100;
        //margem de lucro em porcentagem
        public decimal ProfitMarginPercent { get; set; }
        //Preço de venda
        public decimal SalePrice => FactoryPrice + (FactoryPrice * ProfitMargin);
        //Quantidade
        public int Quantity  { get; set; }
    }
}
