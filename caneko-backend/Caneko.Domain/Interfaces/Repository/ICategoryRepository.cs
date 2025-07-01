using System;
using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Category;

namespace Caneko.Domain.Interfaces.Repository;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<(IEnumerable<Category> products, float totalItems)> Filter(CategoryInputFilterViewModel filter);
    Task Disable(string id, bool isDisable);
}
