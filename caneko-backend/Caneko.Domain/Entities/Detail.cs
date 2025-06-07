namespace Caneko.Domain.Entities
{
    public class Detail
    {
        //Marca
        public required string Brand { get; set; }
        //Use recomendado ex. casa
        public string? UseRecommend { get; set; }
        //Descrição tecnica
        public string? TechnicalDescription { get; set; }
        //Fabricante
        public string? Manufacturer { get; set; }
        //avaliação
        public double? Assessment { get; set; }  // Média de avaliações dos clientes (ex.: 4.5 estrelas)
        public string? Height { get; set; }
        public string? Width { get; set; }
        public string? Weight { get; set; }
        public string[]? TypeColor { get; set; } // tipos de cores para vender
        public string[]? TypeUnits { get; set; } // tamanhos diversos
        public bool IsHighlight { get; set; } // destaque

        public string? SupplierSale { get; set; } // quem vende é a proopria caneko?
    }
}