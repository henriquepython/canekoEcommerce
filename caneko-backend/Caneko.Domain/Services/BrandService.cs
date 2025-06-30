using System;
using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Mappers;
using Caneko.Domain.ViewModels.Brand;

namespace Caneko.Domain.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<BrandViewModel> Create(BrandCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
        }

        var entity = model.MapToEntity();
        var result = await _brandRepository.Create(entity);
        return result.MapToViewModel();
    }

        public async Task Delete(string id) => await _brandRepository.Delete(id);

        public async Task Disable(string id, bool isDisable) => await _brandRepository.Disable(id, isDisable);

        public async Task<BrandOutputFilterPaginationViewModel> Filter(BrandInputFilterViewModel filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
            }

            var result = await _brandRepository.Filter(filter);

            var models = result.products.Select(x => x.MapToOutputFilterViewModel());

            var data = new BrandOutputFilterPaginationViewModel
            {
                Items = models,
                Total = (int)result.totalItems,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber
            };

            return data;
        }

        public async Task<BrandViewModel> FindOne(string id)
        {
            var result = await _brandRepository.FindOne(id);
            return result.MapToViewModel();
        }

        public async Task<IEnumerable<BrandViewModel>> GetAll() {
           var result = await _brandRepository.GetAll();
            return result.Select(x => x.MapToViewModel());
        }

        public async Task<BrandViewModel> Update(string id, BrandUpdateViewModel model)
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
            var update = await _brandRepository.Update(id, entity);
            return update.MapToViewModel();
        }
}
