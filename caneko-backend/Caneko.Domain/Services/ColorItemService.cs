using System;
using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Mappers;
using Caneko.Domain.ViewModels.ColorItem;

namespace Caneko.Domain.Services;

public class ColorItemService : IColorItemService
{
    private readonly IColorRepository _colorItemRepository;

    public ColorItemService(IColorRepository colorItemRepository)
    {
        _colorItemRepository = colorItemRepository;
    }

    public async Task<ColorItemViewModel> Create(ColorItemCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
        }

        var entity = model.MapToEntity();
        var result = await _colorItemRepository.Create(entity);
        return result.MapToViewModel();
    }

    public async Task Delete(string id) => await _colorItemRepository.Delete(id);

    public async Task Disable(string id, bool isDisable) => await _colorItemRepository.Disable(id, isDisable);

    public async Task<ColorItemOutputFilterPaginationViewModel> Filter(ColorItemInputFilterViewModel filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
        }

        var result = await _colorItemRepository.Filter(filter);

        var models = result.products.Select(x => x.MapToOutputFilterViewModel());

        var data = new ColorItemOutputFilterPaginationViewModel
        {
            Items = models,
            Total = (int)result.totalItems,
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber
        };

        return data;
    }

    public async Task<ColorItemViewModel> FindOne(string id)
    {
        var result = await _colorItemRepository.FindOne(id);
        return result.MapToViewModel();
    }

    public async Task<IEnumerable<ColorItemViewModel>> GetAll() {
       var result = await _colorItemRepository.GetAll();
        return result.Select(x => x.MapToViewModel());
    }

    public async Task<ColorItemViewModel> Update(string id, ColorItemUpdateViewModel model)
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
        var update = await _colorItemRepository.Update(id, entity);
        return update.MapToViewModel();
    }
}
