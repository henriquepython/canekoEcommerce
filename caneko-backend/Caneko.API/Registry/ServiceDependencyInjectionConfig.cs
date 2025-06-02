using Caneko.Domain.Interfaces.Service;

namespace Caneko.API.Registry
{
    public static class ServiceDependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
