using System;
using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Brand;

namespace Caneko.Domain.Mappers;

public static class BrandMapper
{
    public static Brand MapToEntity(this BrandCreateViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Product model cannot be null");
            }

            return new Brand
            {
                Name = model.Name
            };
        }

        public static BrandOutputFilterViewModel MapToOutputFilterViewModel(this Brand model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Product model cannot be null");
            }

            return new BrandOutputFilterViewModel
            {
                Id = model.Id,
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate,
                Deleted = model.Deleted,
                Name = model.Name,
            };
        }

        public static Brand MapToEntity(this BrandUpdateViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Product model cannot be null");
            }

            return new Brand(model.Deleted, model.CreateDate, model.UpdateDate)
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static BrandViewModel MapToViewModel(this Brand entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Product entity cannot be null");
            }

            return new BrandViewModel
            {
                Id = entity.Id ?? string.Empty,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
                Deleted = entity.Deleted,
                Name = entity.Name,
            };
        }
}
