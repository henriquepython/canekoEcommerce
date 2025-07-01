using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Category;

public class CategoryInputFilterViewModel : ParameterPageViewModel
{
    [JsonPropertyName("search")]
    public string? Search { get; set; } = string.Empty;
}
