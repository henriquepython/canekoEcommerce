using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Services;

namespace Caneko.API.Registry
{
    public static class ServiceDependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IColorItemService, ColorItemService>();
            services.AddScoped<IRecommendService, RecommendService>();
        }
    }
}
