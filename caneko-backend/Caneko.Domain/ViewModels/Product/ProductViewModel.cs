using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductViewModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [JsonPropertyName("createDate")]
        public DateOnly? CreateDate { get; set; }

        [JsonPropertyName("updateDate")]
        public DateOnly? UpdateDate { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("sequencialId")]
        public string? SequencialId { get; set; }

        [JsonPropertyName("stockId")]
        public string? StockId { get; set; }

        [JsonPropertyName("categoryId")]
        public string? CategoryId { get; set; }

        [JsonPropertyName("brandId")]
        public string? BrandId { get; set; }

        [JsonPropertyName("imagePrincipalUrl")]
        public string? ImagePrincipalUrl { get; set; }

        [JsonPropertyName("imageSecondaryUrl")]
        public List<string>? ImageSecondaryUrl { get; set; }

        [JsonPropertyName("manufacturerId")]
        public string? ManufacturerId { get; set; }

        [JsonPropertyName("supplierSaleId")]
        public string? SupplierSaleId { get; set; }

        [JsonPropertyName("technicalDescription")]
        public string? TechnicalDescription { get; set; }

        [JsonPropertyName("heightProduct")]
        public int? HeightProduct { get; set; }

        [JsonPropertyName("widthProduct")]
        public int? WidthProduct { get; set; }

        [JsonPropertyName("weightProduct")]
        public int? WeightProduct { get; set; }

        [JsonPropertyName("typeColorId")]
        public string? TypeColorId { get; set; }

        [JsonPropertyName("size")]
        public double? Size { get; set; }

        [JsonPropertyName("bussinesUnitId")]
        public string? BussinesUnitId { get; set; }

        [JsonPropertyName("useRecommendId")]
        public string[]? UseRecommendId { get; set; }

        [JsonPropertyName("isHighlight")]
        public bool? IsHighlight { get; set; }
    }
}
