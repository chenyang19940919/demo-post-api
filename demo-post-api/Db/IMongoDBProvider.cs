using MongoDB.Driver;

namespace demo_post_api.Db
{
    public interface IMongoDBProvider
    {
        public IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
