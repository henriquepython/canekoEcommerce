using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Recommend;

public class RecommendOutputFilterPaginationViewModel : ParameterPageViewModel
{
    [JsonPropertyName("items")]
    public IEnumerable<RecommendOutputFilterViewModel> Items { get; set; } = new List<RecommendOutputFilterViewModel>();
}
