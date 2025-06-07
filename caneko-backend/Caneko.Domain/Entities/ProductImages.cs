namespace Caneko.Domain.Entities
{
    public class ProductImages
    {
        public string? ImagePrincipalUrl { get; set; }
        public List<string> ImageSecondaryUrl { get; set; } = new List<string>();
    }
}
