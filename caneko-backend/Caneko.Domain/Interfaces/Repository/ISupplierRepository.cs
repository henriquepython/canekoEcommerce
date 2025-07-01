using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Supplier;

namespace Caneko.Domain.Interfaces.Repository;

public interface ISupplierRepository: IGenericRepository<Supplier>
{
    Task<(IEnumerable<Supplier> products, float totalItems)> Filter(SupplierInputFilterViewModel filter);
    Task Disable(string id, bool isDisable);
}
