using System;
using Caneko.Domain.ViewModels.Manufacturer;

namespace Caneko.Domain.Interfaces.Service;

public interface IManufacturerService
{
    Task<IEnumerable<ManufacturerViewModel>> GetAll();
    Task<ManufacturerOutputFilterPaginationViewModel> Filter(ManufacturerInputFilterViewModel filter);
    Task<ManufacturerViewModel> FindOne(string id);
    Task<ManufacturerViewModel> Create(ManufacturerCreateViewModel entity);
    Task<ManufacturerViewModel> Update(string id, ManufacturerUpdateViewModel entity);
    Task Delete(string id);
    Task Disable(string id, bool isDisable);
}
