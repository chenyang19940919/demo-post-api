using Amazon.Util;
using demo_post_api.Helpers;
using demo_post_api.Models;
using demo_post_api.Repository;
using DnsClient;

namespace demo_post_api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<UserInfo> _repository;

        public AuthService(IRepository<UserInfo> repository)
        {
            _repository = repository;
        }


        public async Task<bool> IsAuthenticatedAsync(string email, string password)
        {
            var users = await _repository.GetAsync();

            var hashPassword = EncryptHelper.SHA256Encrypt(password);

            return users.Any(x => x.Email == email && x.Password == hashPassword);
        }
    }
}
