using demo_post_api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace demo_post_api.Db
{
    public class MongoDBProvider : IMongoDBProvider
    {
        private readonly IMongoDatabase _database;
        public MongoDBProvider(IOptionsMonitor<MongoDBSettings> dbConfig)
        {
            var settings = MongoClientSettings.FromConnectionString(dbConfig.CurrentValue.ConnectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            _database = client.GetDatabase(dbConfig.CurrentValue.DatabaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
