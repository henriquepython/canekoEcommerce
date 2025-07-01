using System;
using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Mappers;
using Caneko.Domain.ViewModels.Category;

namespace Caneko.Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryViewModel> Create(CategoryCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Product entity cannot be null");
        }

        var entity = model.MapToEntity();
        var result = await _categoryRepository.Create(entity);
        return result.MapToViewModel();
    }

    public async Task Delete(string id) => await _categoryRepository.Delete(id);

    public async Task Disable(string id, bool isDisable) => await _categoryRepository.Disable(id, isDisable);

    public async Task<CategoryOutputFilterPaginationViewModel> Filter(CategoryInputFilterViewModel filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
        }

        var result = await _categoryRepository.Filter(filter);

        var models = result.products.Select(x => x.MapToOutputFilterViewModel());

        var data = new CategoryOutputFilterPaginationViewModel
        {
            Items = models,
            Total = (int)result.totalItems,
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber
        };

        return data;
    }

    public async Task<CategoryViewModel> FindOne(string id)
    {
        var result = await _categoryRepository.FindOne(id);
        return result.MapToViewModel();
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAll() {
       var result = await _categoryRepository.GetAll();
        return result.Select(x => x.MapToViewModel());
    }

    public async Task<CategoryViewModel> Update(string id, CategoryUpdateViewModel model)
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
        var update = await _categoryRepository.Update(id, entity);
        return update.MapToViewModel();
    }
}
