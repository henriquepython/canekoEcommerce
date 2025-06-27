namespace Caneko.Domain.Entities
{
    public class Detail
    {
        //Marca
        public string? BrandId { get; set; }
        //Use recomendado ex. casa
        public string? UseRecommendId { get; set; }
        //Descrição tecnica
        public string? TechnicalDescription { get; set; }
        //Fabricante
        public string? ManufacturerId { get; set; }
        //avaliação
        public double? Assessment { get; set; }  // Média de avaliações dos clientes (ex.: 4.5 estrelas)
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? Weight { get; set; }
        public string? TypeColorId { get; set; } // tipos de cores para vender
        public double? Size { get; set; } // tamanhos diversos
        public string? BussinesUnitId { get; set; } // tamanhos diversos
        public bool IsHighlight { get; set; } // destaque

        public string? SupplierSaleId { get; set; } // quem vende é a proopria caneko?
    }
}