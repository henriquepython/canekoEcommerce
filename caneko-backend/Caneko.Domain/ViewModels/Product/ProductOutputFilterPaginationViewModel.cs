using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductOutputFilterPaginationViewModel : ParameterPageViewModel
    {
        [JsonPropertyName("products")]
        public IEnumerable<ProductOutputFilterViewModel> Products { get; set; }
    }
}
