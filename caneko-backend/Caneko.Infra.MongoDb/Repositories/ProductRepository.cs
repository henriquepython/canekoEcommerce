using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.System.Names;
using Microsoft.Extensions.Configuration;

namespace Caneko.Infra.MongoDb.Repositories
{
    public class ProductRepository: GenericMongoRepository<Product>, IProductRepository
    {
        private readonly IConfiguration _configuration;
        
        public ProductRepository(IConfiguration configuration): base(configuration)
        {
               _configuration = configuration;
               COLLECTION_NAME = CollectionNames.PRODUCT;
        }

        public Task Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindOne(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
