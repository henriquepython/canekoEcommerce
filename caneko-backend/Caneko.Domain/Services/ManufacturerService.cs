using System;
using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Mappers;
using Caneko.Domain.ViewModels.Manufacturer;

namespace Caneko.Domain.Services;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufactureRepository _manufacturerRepository;

    public ManufacturerService(IManufactureRepository manufacturerRepository)
    {
        _manufacturerRepository = manufacturerRepository;
    }

    public async Task<ManufacturerViewModel> Create(ManufacturerCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
        }

        var entity = model.MapToEntity();
        var result = await _manufacturerRepository.Create(entity);
        return result.MapToViewModel();
    }

    public async Task Delete(string id) => await _manufacturerRepository.Delete(id);

    public async Task Disable(string id, bool isDisable) => await _manufacturerRepository.Disable(id, isDisable);

    public async Task<ManufacturerOutputFilterPaginationViewModel> Filter(ManufacturerInputFilterViewModel filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
        }

        var result = await _manufacturerRepository.Filter(filter);

        var models = result.products.Select(x => x.MapToOutputFilterViewModel());

        var data = new ManufacturerOutputFilterPaginationViewModel
        {
            Items = models,
            Total = (int)result.totalItems,
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber
        };

        return data;
    }

    public async Task<ManufacturerViewModel> FindOne(string id)
    {
        var result = await _manufacturerRepository.FindOne(id);
        return result.MapToViewModel();
    }

    public async Task<IEnumerable<ManufacturerViewModel>> GetAll() {
       var result = await _manufacturerRepository.GetAll();
        return result.Select(x => x.MapToViewModel());
    }

    public async Task<ManufacturerViewModel> Update(string id, ManufacturerUpdateViewModel model)
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
        var update = await _manufacturerRepository.Update(id, entity);
        return update.MapToViewModel();
    }
}
