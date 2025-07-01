using System;
using Caneko.Domain.ViewModels.Category;

namespace Caneko.Domain.Interfaces.Service;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAll();
    Task<CategoryOutputFilterPaginationViewModel> Filter(CategoryInputFilterViewModel filter);
    Task<CategoryViewModel> FindOne(string id);
    Task<CategoryViewModel> Create(CategoryCreateViewModel entity);
    Task<CategoryViewModel> Update(string id, CategoryUpdateViewModel entity);
    Task Delete(string id);
    Task Disable(string id, bool isDisable);
}
