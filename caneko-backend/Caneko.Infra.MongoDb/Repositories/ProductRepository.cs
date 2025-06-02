using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.System.Names;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SharpCompress.Common;

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

        public async Task<Product> Create(Product entity)
        {
            try
            {
                if (entity == null) 
                    throw new ArgumentNullException(nameof(entity));

                await _Collection.InsertOneAsync(entity);
                return entity;
            }
            catch (Exception Ex)
            {

                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentNullException(nameof(id));

                await _Collection.DeleteOneAsync(id);
            }
            catch (Exception Ex)
            {

                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }

        public async Task<Product> FindOne(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentNullException(nameof(id));

                var result = await _Collection.FindAsync(x => x.Id == id && !x.Deleted);
                return result.SingleOrDefault();
            }
            catch (Exception Ex)
            {

                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var result = await _Collection.FindAsync(x => !x.Deleted);
                return result.ToList();
            }
            catch (Exception Ex)
            {

                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }

        public async Task<Product> Update(string id, Product entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentNullException(nameof(id));

                var filter = Builders<Product>.Filter.And(
                    Builders<Product>.Filter.Eq(x => x.Id, id),
                    Builders<Product>.Filter.Eq(x => x.Deleted, false)
                );

                var options = new FindOneAndReplaceOptions<Product, Product>
                {
                    ReturnDocument = ReturnDocument.After
                };

                var result = await _Collection.FindOneAndReplaceAsync(filter, entity, options);

                return result;
            }
            catch (Exception Ex)
            {
                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }
    }
}
