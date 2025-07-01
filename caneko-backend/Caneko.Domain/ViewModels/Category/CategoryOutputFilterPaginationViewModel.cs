using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Category;

public class CategoryOutputFilterPaginationViewModel : ParameterPageViewModel
{
    [JsonPropertyName("items")]
    public IEnumerable<CategoryOutputFilterViewModel> Items { get; set; } = new List<CategoryOutputFilterViewModel>();
}
