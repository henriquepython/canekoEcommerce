using System;
using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Supplier;

namespace Caneko.Domain.Mappers;

public static class SupplierMapper
{
    public static Supplier MapToEntity(this SupplierCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new Supplier
        {
            Name = model.Name
        };
    }

    public static SupplierOutputFilterViewModel MapToOutputFilterViewModel(this Supplier model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new SupplierOutputFilterViewModel
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Deleted = model.Deleted,
            Name = model.Name,
        };
    }

    public static Supplier MapToEntity(this SupplierUpdateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new Supplier(model.Deleted, model.CreateDate, model.UpdateDate)
        {
            Id = model.Id,
            Name = model.Name,
        };
    }

    public static SupplierViewModel MapToViewModel(this Supplier entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
        }
        return new SupplierViewModel
        {
            Id = entity.Id ?? string.Empty,
            CreateDate = entity.CreateDate,
            UpdateDate = entity.UpdateDate,
            Deleted = entity.Deleted,
            Name = entity.Name,
        };
    }
}
