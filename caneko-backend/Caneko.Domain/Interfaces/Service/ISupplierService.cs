using System;
using Caneko.Domain.ViewModels.Supplier;

namespace Caneko.Domain.Interfaces.Service;

public interface ISupplierService
{
    Task<IEnumerable<SupplierViewModel>> GetAll();
    Task<SupplierOutputFilterPaginationViewModel> Filter(SupplierInputFilterViewModel filter);
    Task<SupplierViewModel> FindOne(string id);
    Task<SupplierViewModel> Create(SupplierCreateViewModel entity);
    Task<SupplierViewModel> Update(string id, SupplierUpdateViewModel entity);
    Task Delete(string id);
    Task Disable(string id, bool isDisable);
}
