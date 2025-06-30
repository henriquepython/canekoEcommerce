using System;
using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Brand;

namespace Caneko.Domain.Interfaces.Repository;

public interface IBrandRepository : IGenericRepository<Brand>
{
    Task<(IEnumerable<Brand> products, float totalItems)> Filter(BrandInputFilterViewModel filter);
    Task Disable(string id, bool isDisable);
}
