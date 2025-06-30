using Caneko.Domain.Entities;

namespace Caneko.Domain.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public ProductImages? Images { get; set; }
        public Detail? Details { get; set; }
    }
}
