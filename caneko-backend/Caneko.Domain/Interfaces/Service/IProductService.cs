using Caneko.Domain.ViewModels.Product;

namespace Caneko.Domain.Interfaces.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> FindOne(string id);
        Task<ProductViewModel> Create(ProductCreateViewModel entity);
        Task<ProductViewModel> Update(string id, ProductUpdateViewModel entity);
        Task Delete(string id);
    }
}
