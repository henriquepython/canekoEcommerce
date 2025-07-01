using Caneko.Domain.Interfaces.Repository;
using Caneko.Infra.MongoDb.Repositories;

namespace Caneko.API.Registry
{
    public class RepositoryDependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IRecommendRepository, RecommendRepository>();
            services.AddScoped<IColorRepository, ColorItemRepository>();
            services.AddScoped<IManufactureRepository, ManufacturerRepository>();
        }
    }
}
