using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Supplier;

public class SupplierInputFilterViewModel : ParameterPageViewModel
{
    [JsonPropertyName("search")]
    public string? Search { get; set; } = string.Empty;
}
