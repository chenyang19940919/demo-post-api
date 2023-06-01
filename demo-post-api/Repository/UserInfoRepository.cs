using demo_post_api.Db;
using demo_post_api.Models;
using MongoDB.Driver;

namespace demo_post_api.Repository
{
    public class UserInfoRepository : IRepository<UserInfo>
    {
        private IMongoCollection<UserInfo> _userInfoCollection;
        public UserInfoRepository(IMongoDBProvider _mongoDB)
        {
            _userInfoCollection = _mongoDB.GetCollection<UserInfo>("UserInfo");
        }

        public async Task CreateAsync(UserInfo model)
        {
            await _userInfoCollection.InsertOneAsync(model);

        }

        public async Task DeleteAsync(string id)
        {
            await _userInfoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<UserInfo>> GetAsync()
        {
            return await _userInfoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<UserInfo> GetAsync(string id)
        {
            return await _userInfoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, UserInfo model)
        {
            await _userInfoCollection.ReplaceOneAsync(x => x.Id == id, model);
        }
    }
}
