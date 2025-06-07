using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Product;

namespace Caneko.Domain.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> Filter(ProductInputFilterViewModel filter);
        Task Disable(string id, bool isDisable);
    }
}
