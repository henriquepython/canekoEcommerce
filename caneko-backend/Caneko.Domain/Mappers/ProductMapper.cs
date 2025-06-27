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
                Description = model.Description,
                Deleted = model.Deleted,
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate,
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
                UpdateDate = model.UpdateDate,
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
                Id = entity.Id,
                Deleted = entity.Deleted,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
                Name = entity.Name,
                Description = entity.Description,
                SequencialId = entity.SequencialId,
                StockId = entity.StockId,
                Category = entity.Category.Name,
                Brand = entity?.Details?.Brand,
                ImagePrincipalUrl = entity?.Images?.ImagePrincipalUrl,
                ImageSecondaryUrl = entity?.Images?.ImageSecondaryUrl,
                Manufacturer = entity?.Details?.Manufacturer,
                SupplierSale = entity?.Details?.SupplierSale,
                TechnicalDescription = entity?.Details?.TechnicalDescription,
                HeightProduct = entity?.Details?.Height,
                WidthProduct = entity?.Details?.Width,
                WeightProduct = entity?.Details?.Weight,
                TypeColor = entity?.Details?.TypeColor,
                UseRecommend = entity?.Details?.UseRecommend,
                IsHighlight = entity?.Details?.IsHighlight
            };
        }
    }
}
