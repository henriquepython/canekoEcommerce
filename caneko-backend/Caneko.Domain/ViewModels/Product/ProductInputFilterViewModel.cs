using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductInputFilterViewModel : ParameterPageViewModel
    {
        [JsonPropertyName("search")]
        public string? Search { get; set; } = string.Empty;

        [JsonPropertyName("isStock")]
        public bool IsStock { get; set; } = false;
    }
}
