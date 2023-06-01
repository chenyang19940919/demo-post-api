namespace demo_post_api.Services.Auth
{
    public interface IAuthService
    {
        public Task<bool> IsAuthenticatedAsync(string email, string password);
    }
}
