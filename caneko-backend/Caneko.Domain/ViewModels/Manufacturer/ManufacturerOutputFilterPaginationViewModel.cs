using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Manufacturer;

public class ManufacturerOutputFilterPaginationViewModel : ParameterPageViewModel
{
    [JsonPropertyName("items")]
    public IEnumerable<ManufacturerOutputFilterViewModel> Items { get; set; } = new List<ManufacturerOutputFilterViewModel>();
}
