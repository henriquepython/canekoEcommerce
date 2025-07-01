using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Manufacturer;

namespace Caneko.Domain.Interfaces.Repository;

public interface IManufactureRepository: IGenericRepository<Manufacturer>
{
    Task<(IEnumerable<Manufacturer> products, float totalItems)> Filter(ManufacturerInputFilterViewModel filter);
    Task Disable(string id, bool isDisable);
}