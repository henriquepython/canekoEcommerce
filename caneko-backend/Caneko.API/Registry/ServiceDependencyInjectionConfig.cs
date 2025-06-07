using Caneko.Domain.Interfaces.Service;
using Caneko.Domain.Services;

namespace Caneko.API.Registry
{
    public static class ServiceDependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
