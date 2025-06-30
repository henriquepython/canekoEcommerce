using System;
using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels.Brand;

public class BrandUpdateViewModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("createDate")]
    public DateOnly? CreateDate { get; set; }

    [JsonPropertyName("updateDate")]
    public DateOnly? UpdateDate { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
