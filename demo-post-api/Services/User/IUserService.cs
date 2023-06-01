using demo_post_api.Models;

namespace demo_post_api.Services.User
{
    public interface IUserService
    {
        public Task<UserInfo> GetUser(string email);

        public Task<List<UserInfo>> GetUsers();

        
    }
}
