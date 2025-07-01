using System;
using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Category;

namespace Caneko.Domain.Mappers;

public static class CategoryMapper
{
    public static Category MapToEntity(this CategoryCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new Category
        {
            Name = model.Name
        };
    }

    public static CategoryOutputFilterViewModel MapToOutputFilterViewModel(this Category model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new CategoryOutputFilterViewModel
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Deleted = model.Deleted,
            Name = model.Name,
        };
    }

    public static Category MapToEntity(this CategoryUpdateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new Category
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Deleted = model.Deleted,
            Name = model.Name,
        };
    }

    public static CategoryViewModel MapToViewModel(this Category entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
        }
        return new CategoryViewModel
        {
            Id = entity.Id ?? string.Empty,
            CreateDate = entity.CreateDate,
            UpdateDate = entity.UpdateDate,
            Deleted = entity.Deleted,
            Name = entity.Name,
        };
    }
}
