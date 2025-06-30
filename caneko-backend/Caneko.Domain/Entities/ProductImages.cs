using MongoDB.Bson.Serialization.Attributes;

namespace Caneko.Domain.Entities
{
    public class ProductImages
    {
        [BsonElement("imagePrincipalUrl")]
        public string? ImagePrincipalUrl { get; set; }

        [BsonElement("imageSecondaryUrl")]
        public List<string> ImageSecondaryUrl { get; set; } = new List<string>();
    }
}
