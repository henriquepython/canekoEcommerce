using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities
{
    public class Detail
    {
        [BsonElement("brandId")]
        public string? BrandId { get; set; }
        
        [BsonElement("useRecommendId")]
        public string[]? UseRecommendId { get; set; }
       
       
        [BsonElement("technicalDescription")]
        public string? TechnicalDescription { get; set; }
        
        [BsonElement("manufacturerId")]
        public string? ManufacturerId { get; set; }
        
        [BsonElement("assessment")]
        public double? Assessment { get; set; }  // Média de avaliações dos clientes (ex.: 4.5 estrelas)

        [BsonElement("height")]
        public int? Height { get; set; }

        [BsonElement("width")]
        public int? Width { get; set; }

        [BsonElement("weight")]
        public int? Weight { get; set; }

        [BsonElement("typeColorId")]
        public string? TypeColorId { get; set; }

        [BsonElement("size")]
        public double? Size { get; set; }

        [BsonElement("bussinesUnitId")]
        public string? BussinesUnitId { get; set; }

        [BsonElement("isHighlight")]
        public bool IsHighlight { get; set; }

        [BsonElement("supplierSaleId")]
        public string? SupplierSaleId { get; set; }
    }
}