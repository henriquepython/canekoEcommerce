using System;
using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.Domain.ViewModels.ColorItem;
using Caneko.System.Names;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Caneko.Infra.MongoDb.Repositories;

public class ColorItemRepository : GenericMongoRepository<ColorItem>, IColorRepository
{
    private readonly IConfiguration _configuration;
    protected override string COLLECTION_NAME => CollectionNames.COLOR_ITEM;
    
    public ColorItemRepository(IConfiguration configuration) : base(configuration)
    {
        _configuration = configuration;
    }

    public async Task<ColorItem> Create(ColorItem entity)
        {
            try
            {
                if (entity == null) 
                    throw new ArgumentNullException(nameof(entity));

                entity.CreateDate = DateOnly.FromDateTime(DateTime.Now);
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

                var filter = Builders<ColorItem>.Filter.Eq(x => x.Id, id);

                await _Collection.DeleteOneAsync(filter);
            }
            catch (Exception Ex)
            {

                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }

        public async Task<(IEnumerable<ColorItem> products, float totalItems)> Filter(ColorItemInputFilterViewModel filter)
        {
            try
            {
                if (filter == null)
                    throw new ArgumentNullException(nameof(filter));

                var builder = Builders<ColorItem>.Filter;
                var filters = new List<FilterDefinition<ColorItem>>();

                if (!string.IsNullOrWhiteSpace(filter.Search))
                {
                    filters.Add(builder.Regex(x => x.Name, new BsonRegularExpression(filter.Search, "i")));
                }
 
                var combinedFilter = filters.Count > 0 ? builder.And(filters) : builder.Empty;

                var total = await _Collection.CountDocumentsAsync(combinedFilter);

                var skip = (filter.PageNumber - 1) * filter.PageSize;
                var result = await _Collection.Find(combinedFilter)
                    .Skip(skip)
                    .Limit(filter.PageSize)
                    .ToListAsync();

                return ( result, total );
            }
            catch (Exception Ex)
            {
                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }

        public async Task<ColorItem> FindOne(string id)
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

        public async Task<IEnumerable<ColorItem>> GetAll()
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

        public async Task<ColorItem> Update(string id, ColorItem entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentNullException(nameof(id));

                var filter = Builders<ColorItem>.Filter.And(
                    Builders<ColorItem>.Filter.Eq(x => x.Id, id),
                    Builders<ColorItem>.Filter.Eq(x => x.Deleted, false)
                );

                var options = new FindOneAndReplaceOptions<ColorItem, ColorItem>
                {
                    ReturnDocument = ReturnDocument.After
                };

                entity.UpdateDate = DateOnly.FromDateTime(DateTime.Now);

                var result = await _Collection.FindOneAndReplaceAsync(filter, entity, options);

                return result;
            }
            catch (Exception Ex)
            {
                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }

        public async Task Disable(string id, bool isDisable )
        {
            try
            {

                var filter = Builders<ColorItem>.Filter.And(
                        Builders<ColorItem>.Filter.Eq(x => x.Id, id)
                    );

                var update = Builders<ColorItem>.Update
                    .Set(p => p.Deleted, isDisable)
                    .Set(p => p.UpdateDate, DateOnly.FromDateTime(DateTime.Now));

                await _Collection.UpdateOneAsync(filter, update);

            } catch (Exception Ex)
            {
                throw new ArgumentException("Ocorreu um erro", Ex);
            }
        }
}