using Caneko.Domain.Entities;
using Caneko.Domain.Interfaces.Repository;
using Caneko.System.Names;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caneko.Infra.MongoDb.Repositories
{
    public class StockRepository : GenericMongoRepository<Stock>, IStockRepository
    {
        private readonly IConfiguration _configuration;
        protected override string COLLECTION_NAME => CollectionNames.STOCK;

        public StockRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public Task<Product> Create(Stock entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Stock>> FindByIds(IEnumerable<string> ids)
        {
            var stocksItems = await _Collection.FindAsync(x => ids.Contains(x.Id) && !x.Deleted);

            return stocksItems.ToList();
        }

        public Task<Stock> FindOne(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Stock>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Stock> Update(string id, Stock entity)
        {
            throw new NotImplementedException();
        }
    }
}
