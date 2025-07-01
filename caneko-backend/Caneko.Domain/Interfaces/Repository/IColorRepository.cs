using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.ColorItem;

namespace Caneko.Domain.Interfaces.Repository;

public interface IColorRepository: IGenericRepository<ColorItem>
{
    Task<(IEnumerable<ColorItem> products, float totalItems)> Filter(ColorItemInputFilterViewModel filter);
    Task Disable(string id, bool isDisable);
}
