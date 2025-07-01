using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Supplier;

public class SupplierOutputFilterPaginationViewModel : ParameterPageViewModel
{
    [JsonPropertyName("items")]
    public IEnumerable<SupplierOutputFilterViewModel> Items { get; set; } = new List<SupplierOutputFilterViewModel>();
}
