using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Brand;

public class BrandInputFilterViewModel : ParameterPageViewModel
{
    [JsonPropertyName("search")]
    public string? Search { get; set; } = string.Empty;
}
