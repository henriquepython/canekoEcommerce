using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.ViewModels.Product;
using Caneko.System.Names;
using Caneko.System.Util;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Caneko.Infra.MongoDb.Repositories
{
    public class ProductRepository : GenericMongoRepository<Product>, IProductRepository
    {
        private readonly IConfiguration _configuration;
        protected override string COLLECTION_NAME => CollectionNames.PRODUCT;

        public ProductRepository(IConfiguration configuration): base(configuration)
        {
               _configuration = configuration;
        }

        public async Task<Product> Create(Product entity)
        {
            try
            {
                if (entity == null) 
                    throw new ArgumentNullException(nameof(entity));

                entity.SequencialId = NumberGenerator.GetShortHashByDateNow();
                entity.CreateDate = DateTime.Now;
                entity.Deleted = false;

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

        public async Task<IEnumerable<Product>> Filter(ProductInputFilterViewModel filter)
        {
            try
            {
                if (filter == null)
                    throw new ArgumentNullException(nameof(filter));

                var builder = Builders<Product>.Filter;
                var filters = new List<FilterDefinition<Product>>
                {
                    builder.Eq(x => x.Deleted, false)
                };

                // Add search filter  
                if (!string.IsNullOrWhiteSpace(filter.Search))
                {
                    filters.Add(builder.Regex(x => x.Name, new BsonRegularExpression(filter.Search, "i")));
                }

                // Combine filters  
                var combinedFilter = filters.Count > 0 ? builder.And(filters) : builder.Empty;

                // Pagination  
                var skip = (filter.PageNumber - 1) * filter.PageSize;
                var result = await _Collection.Find(combinedFilter)
                    .Skip(skip)
                    .Limit(filter.PageSize)
                    .ToListAsync();

                return result;
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

                entity.UpdateDate = DateTime.Now;

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
