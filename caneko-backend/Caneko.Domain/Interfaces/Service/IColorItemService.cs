using System;
using Caneko.Domain.ViewModels.ColorItem;

namespace Caneko.Domain.Interfaces.Service;

public interface IColorItemService
{
    Task<IEnumerable<ColorItemViewModel>> GetAll();
    Task<ColorItemOutputFilterPaginationViewModel> Filter(ColorItemInputFilterViewModel filter);
    Task<ColorItemViewModel> FindOne(string id);
    Task<ColorItemViewModel> Create(ColorItemCreateViewModel entity);
    Task<ColorItemViewModel> Update(string id, ColorItemUpdateViewModel entity);
    Task Delete(string id);
    Task Disable(string id, bool isDisable);
}
