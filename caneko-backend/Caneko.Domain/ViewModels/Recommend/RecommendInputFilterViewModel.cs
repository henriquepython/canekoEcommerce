using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Recommend;

public class RecommendInputFilterViewModel : ParameterPageViewModel
{
    [JsonPropertyName("search")]
    public string? Search { get; set; } = string.Empty;
}
