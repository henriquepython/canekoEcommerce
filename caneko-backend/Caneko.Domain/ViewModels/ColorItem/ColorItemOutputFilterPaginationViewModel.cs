using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.ColorItem;

public class ColorItemOutputFilterPaginationViewModel : ParameterPageViewModel
{
    [JsonPropertyName("items")]
    public IEnumerable<ColorItemOutputFilterViewModel> Items { get; set; } = new List<ColorItemOutputFilterViewModel>();
}
