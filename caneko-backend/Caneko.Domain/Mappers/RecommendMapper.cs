using System;
using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Recommend;

namespace Caneko.Domain.Mappers;

public static class RecommendMapper
{
    public static Recommend MapToEntity(this RecommendCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new Recommend
        {
            Name = model.Name
        };
    }

    public static RecommendOutputFilterViewModel MapToOutputFilterViewModel(this Recommend model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new RecommendOutputFilterViewModel
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Deleted = model.Deleted,
            Name = model.Name,
        };
    }

    public static Recommend MapToEntity(this RecommendUpdateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        return new Recommend
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Deleted = model.Deleted,
            Name = model.Name,
        };
    }

    public static RecommendViewModel MapToViewModel(this Recommend entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
        }
        return new RecommendViewModel
        {
            Id = entity.Id ?? string.Empty,
            CreateDate = entity.CreateDate,
            UpdateDate = entity.UpdateDate,
            Deleted = entity.Deleted,
            Name = entity.Name,
        };
    }
}
