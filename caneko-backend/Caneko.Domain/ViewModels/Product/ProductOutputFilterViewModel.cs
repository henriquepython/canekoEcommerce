using Caneko.Domain.Entities;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductOutputFilterViewModel
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("sequencialId")]
        public required string SequencialId { get; set; }

        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime? CreateDate { get; set; } // tooltip data produto

        [JsonPropertyName("updateDate")]
        public DateTime? UpdateDate { get; set; } // tooltip data produto

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        //stock => usar tooltip estoque
        [JsonPropertyName("stock")]
        public Stock? Stock { get; set; }
        //stock

        [JsonPropertyName("category")]
        public Category? Category { get; set; }

        [JsonPropertyName("images")]
        public ProductImages? Images { get; set; }

        [JsonPropertyName("details")]
        public Detail? Details { get; set; }


    }
}
