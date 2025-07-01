using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.ColorItem;

public class ColorItemInputFilterViewModel : ParameterPageViewModel
{
    [JsonPropertyName("search")]
    public string? Search { get; set; } = string.Empty;
}
