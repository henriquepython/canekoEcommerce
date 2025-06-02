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
                Deleted = model.Deleted,
                CreateDate = model.CreateDate ?? DateTime.UtcNow,
                UpdateDate = model.UpdateDate ?? DateTime.UtcNow,
                Name = model.Name,
                Description = model.Description,
                StockId = model.StockId,
                CategoryId = model.CategoryId,
                ImagePrincipalUrl = model.ImagePrincipalUrl,
                Details = model.Details,
                ImageSecondaryUrl = model.ImageSecondaryUrl,
                IsHighlight = model.IsHighlight,
                TypeColor = model.TypeColor,
                TypeUnits = model.TypeUnits,
                SupplierSale = model.SupplierSale
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
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate ?? DateTime.UtcNow,
                Name = model.Name,
                Description = model.Description,
                StockId = model.StockId,
                CategoryId = model.CategoryId,
                ImagePrincipalUrl = model.ImagePrincipalUrl,
                Details = model.Details,
                ImageSecondaryUrl = model.ImageSecondaryUrl,
                IsHighlight = model.IsHighlight,
                TypeColor = model.TypeColor,
                TypeUnits = model.TypeUnits,
                SupplierSale = model.SupplierSale
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
                StockId = entity.StockId,
                CategoryId = entity.CategoryId,
                ImagePrincipalUrl = entity.ImagePrincipalUrl,
                Details = entity.Details,
                ImageSecondaryUrl = entity.ImageSecondaryUrl,
                IsHighlight = entity.IsHighlight,
                TypeColor = entity.TypeColor,
                TypeUnits = entity.TypeUnits,
                SupplierSale = entity.SupplierSale
            };
        }
    }
}
