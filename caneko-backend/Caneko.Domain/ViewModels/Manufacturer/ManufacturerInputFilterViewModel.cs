using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Manufacturer;

public class ManufacturerInputFilterViewModel : ParameterPageViewModel
{
    [JsonPropertyName("search")]
    public string? Search { get; set; } = string.Empty;
}
