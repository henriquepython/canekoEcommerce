using System.Text.Json.Serialization;

namespace Caneko.Domain.ViewModels
{
    public class DisableInputViewModel
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("isDisable")]
        public required bool IsDisable { get; set; }
    }
}
