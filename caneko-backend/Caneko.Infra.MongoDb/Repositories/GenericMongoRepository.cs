using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Caneko.Infra.MongoDb.Repositories
{
    public class GenericMongoRepository<T> where T : class
    {
        public required virtual string COLLECTION_NAME { get; set; }
        public IMongoCollection<T> _Collection { get; set; }

        public GenericMongoRepository(IConfiguration config)
        {
            string connectionString = config["MongoDb:ConnectionString"] ?? string.Empty;
            string databaseName = config["MongoDb:DatabaseName"] ?? string.Empty;

            ArgumentNullException.ThrowIfNullOrEmpty(connectionString);
            ArgumentNullException.ThrowIfNullOrEmpty(databaseName);

            var client = new MongoClient(connectionString);
            var collection = client.GetDatabase(databaseName).GetCollection<T>(COLLECTION_NAME);
           
            _Collection = collection;
        }


    }
}
