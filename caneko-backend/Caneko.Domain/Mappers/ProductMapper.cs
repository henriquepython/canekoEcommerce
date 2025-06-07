using Caneko.Domain.Entities;
using Caneko.Domain.ViewModels.Product;

namespace Caneko.Domain.Mappers
{
    public static class ProductMapper
    {
        public static Product MapToEntity(this ProductCreateViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Product model cannot be null");
            }

            return new Product
            {
                Id = string.Empty,
                SequencialId = string.Empty,
                StockId = string.Empty,
                Name = model.Name,
                Description = model.Description,
                Category = model.Category,
                Images = model.Images,
                Details = model.Details,
            };
        }

        public static ProductOutputFilterViewModel MapToOutputFilterViewModel(this Product model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Product model cannot be null");
            }

            return new ProductOutputFilterViewModel
            {
                Id = model.Id ?? string.Empty,
                SequencialId = model.SequencialId,
                Deleted = model.Deleted,
                CreateDate = model.CreateDate ?? DateTime.UtcNow,
                UpdateDate = model.UpdateDate ?? DateTime.UtcNow,
                Name = model.Name,
                Stock = new Stock() { Id = model.Id},
                Category = model.Category,
                Images = model.Images,
                Details = model.Details,
            };
        }

        public static Product MapToEntity(this ProductUpdateViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Product model cannot be null");
            }

            return new Product
            {
                Deleted = model.Deleted,
                SequencialId = model.SequencialId,
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate ?? DateTime.UtcNow,
                Name = model.Name,
                Description = model.Description,
                StockId = model.StockId,
                Category = model.Category,
                Images = model.Images,
                Details = model.Details,
            };
        }

        public static ProductViewModel MapToViewModel(this Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Product entity cannot be null");
            }

            return new ProductViewModel
            {
                Deleted = entity.Deleted,
                SequencialId = entity.SequencialId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate ?? DateTime.UtcNow,
                Name = entity.Name,
                Description = entity.Description,
                StockId = entity.StockId,
                Category = entity.Category,
                Images = entity.Images,
                Details = entity.Details,
            };
        }
    }
}
