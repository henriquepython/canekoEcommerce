using System;
using Caneko.Domain.ViewModels.Brand;

namespace Caneko.Domain.Interfaces.Service;

public interface IBrandService
{
        Task<IEnumerable<BrandViewModel>> GetAll();
        Task<BrandOutputFilterPaginationViewModel> Filter(BrandInputFilterViewModel filter);
        Task<BrandViewModel> FindOne(string id);
        Task<BrandViewModel> Create(BrandCreateViewModel entity);
        Task<BrandViewModel> Update(string id, BrandUpdateViewModel entity);
        Task Delete(string id);
        Task Disable(string id, bool isDisable);

}
