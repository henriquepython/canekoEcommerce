using System;
using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Mappers;
using Caneko.Domain.ViewModels.Supplier;

namespace Caneko.Domain.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierViewModel> Create(SupplierCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
        }

        var entity = model.MapToEntity();
        var result = await _supplierRepository.Create(entity);
        return result.MapToViewModel();
    }

    public async Task Delete(string id) => await _supplierRepository.Delete(id);

    public async Task Disable(string id, bool isDisable) => await _supplierRepository.Disable(id, isDisable);

    public async Task<SupplierOutputFilterPaginationViewModel> Filter(SupplierInputFilterViewModel filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
        }

        var result = await _supplierRepository.Filter(filter);

        var models = result.products.Select(x => x.MapToOutputFilterViewModel());

        var data = new SupplierOutputFilterPaginationViewModel
        {
            Items = models,
            Total = (int)result.totalItems,
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber
        };

        return data;
    }

    public async Task<SupplierViewModel> FindOne(string id)
    {
        var result = await _supplierRepository.FindOne(id);
        return result.MapToViewModel();
    }

    public async Task<IEnumerable<SupplierViewModel>> GetAll() {
       var result = await _supplierRepository.GetAll();
        return result.Select(x => x.MapToViewModel());
    }

    public async Task<SupplierViewModel> Update(string id, SupplierUpdateViewModel model)
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
        var update = await _supplierRepository.Update(id, entity);
        return update.MapToViewModel();
    }
}
