using System;
using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.ColorItem;

namespace Caneko.Domain.Mappers;

public static class ColorItemMapper
{
    public static ColorItem MapToEntity(this ColorItemCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new ColorItem
        {
            Name = model.Name
        };
    }

    public static ColorItemOutputFilterViewModel MapToOutputFilterViewModel(this ColorItem model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new ColorItemOutputFilterViewModel
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Deleted = model.Deleted,
            Name = model.Name,
        };
    }

    public static ColorItem MapToEntity(this ColorItemUpdateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new ColorItem(model.Deleted, model.CreateDate, model.UpdateDate)
        {
            Id = model.Id,
            Name = model.Name,
        };
    }

    public static ColorItemViewModel MapToViewModel(this ColorItem entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
        }
        return new ColorItemViewModel
        {
            Id = entity.Id ?? string.Empty,
            CreateDate = entity.CreateDate,
            UpdateDate = entity.UpdateDate,
            Deleted = entity.Deleted,
            Name = entity.Name,
        };
    }
}
