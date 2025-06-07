using Caneko.Domain.Interfaces.Repository;
using Caneko.Infra.MongoDb.Repositories;

namespace Caneko.API.Registry
{
    public class RepositoryDependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IStockRepository, StockRepository>();
        }
    }
}
