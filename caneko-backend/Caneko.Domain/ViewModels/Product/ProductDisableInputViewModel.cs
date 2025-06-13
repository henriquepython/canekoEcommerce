using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductDisableInputViewModel
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("isDisable")]
        public required bool IsDisable { get; set; }
    }
}
