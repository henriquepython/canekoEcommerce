using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Mappers;
using Caneko.Domain.ViewModels.Product;

namespace Caneko.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;

        public ProductService(IProductRepository productRepository, IStockRepository stockRepository)
        {
            _productRepository = productRepository;
            _stockRepository = stockRepository;
        }

        public async Task<ProductViewModel> Create(ProductCreateViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
            }

            var entity = model.MapToEntity();
            var result = await _productRepository.Create(entity);
            return result.MapToViewModel();
        }

        public async Task Delete(string id) => await _productRepository.Delete(id);

        public async Task Disable(string id, bool isDisable) => await _productRepository.Disable(id, isDisable);

        public async Task<ProductOutputFilterPaginationViewModel> Filter(ProductInputFilterViewModel filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
            }

            var result = await _productRepository.Filter(filter);

            var models = result.products.Select(x => x.MapToOutputFilterViewModel());

             var stocks = result.products.Select(x => x.StockId)
                .Where(y => !string.IsNullOrWhiteSpace(y))
                .Distinct()
                .ToList();

            if (filter.IsStock && stocks != null && stocks.Any())
            {
                var stocksItems = await _stockRepository.FindByIds(stocks);

                models = models.Select(x =>
                {
                    var stock = stocksItems.FirstOrDefault(s => s.ProductId == x.Id);
                    if (stock != null)
                    {
                        x.Stock = stock;
                    }
                    return x;
                }).ToList();
            }

            var data = new ProductOutputFilterPaginationViewModel
            {
                Products = models,
                Total = (int)result.totalItems,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber
            };

            return data;
        }

        public async Task<ProductViewModel> FindOne(string id)
        {
            var result = await _productRepository.FindOne(id);
            return result.MapToViewModel();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll() {
           var result = await _productRepository.GetAll();
            return result.Select(x => x.MapToViewModel());
        }

        public async Task<ProductViewModel> Update(string id, ProductUpdateViewModel model)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id), "Product ID cannot be null or empty");
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
            }

            var entity = model.MapToEntity();
            var update = await _productRepository.Update(id, entity);
            return update.MapToViewModel();
        }
    }
}
