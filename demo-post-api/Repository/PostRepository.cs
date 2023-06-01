using demo_post_api.Db;
using demo_post_api.Models;
using MongoDB.Driver;

namespace demo_post_api.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private IMongoCollection<Post> _postCollection;
        public PostRepository(IMongoDBProvider _mongoDB)
        {
            _postCollection = _mongoDB.GetCollection<Post>("Post");
        }

        public async Task CreateAsync(Post model)
        {
            await _postCollection.InsertOneAsync(model);
        }

        public async Task DeleteAsync(string id)
        {
            await _postCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<Post>> GetAsync()
        {
            return await _postCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Post> GetAsync(string id)
        {
            return await _postCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, Post model)
        {
            await _postCollection.ReplaceOneAsync(x => x.Id == id, model);
        }
    }
}
