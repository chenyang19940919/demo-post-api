using demo_post_api.Models;
using demo_post_api.Repository;

namespace demo_post_api.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserInfo> _repository;
        public UserService(IRepository<UserInfo> repository)
        {
            _repository = repository;
        }
        public async Task<UserInfo> GetUser(string email)
        {
            var users = await _repository.GetAsync();
            var user = users.Where(x=>x.Email== email).FirstOrDefault();
            return user;
        }

        public async Task<List<UserInfo>> GetUsers()
        {
            var users = await _repository.GetAsync();
            return users;
        }
    }
}
