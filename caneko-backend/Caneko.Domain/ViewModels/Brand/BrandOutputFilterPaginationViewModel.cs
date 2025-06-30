using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Brand;

public class BrandOutputFilterPaginationViewModel : ParameterPageViewModel
{
    [JsonPropertyName("items")]
    public IEnumerable<BrandOutputFilterViewModel> Items { get; set; } = new List<BrandOutputFilterViewModel>();
}
