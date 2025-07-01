using System;
using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Manufacturer;

namespace Caneko.Domain.Mappers;

public static class ManufacturerMapper
{
    public static Manufacturer MapToEntity(this ManufacturerCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new Manufacturer
        {
            Name = model.Name
        };
    }

    public static ManufacturerOutputFilterViewModel MapToOutputFilterViewModel(this Manufacturer model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new ManufacturerOutputFilterViewModel
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Deleted = model.Deleted,
            Name = model.Name,
        };
    }

    public static Manufacturer MapToEntity(this ManufacturerUpdateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new Manufacturer
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Deleted = model.Deleted,
            Name = model.Name,
        };
    }

    public static ManufacturerViewModel MapToViewModel(this Manufacturer entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
        }
        return new ManufacturerViewModel
        {
            Id = entity.Id ?? string.Empty,
            CreateDate = entity.CreateDate,
            UpdateDate = entity.UpdateDate,
            Deleted = entity.Deleted,
            Name = entity.Name,
        };
    }
}
