using demo_post_api.Models;

namespace demo_post_api.Services.PostService
{
    public interface IPostService
    {
        public Task<Post> GetPostAsync(string id);
        public Task<List<Post>> GetPostListAsync();
        public Task UpdatePostAsync(string id, Post model);
        public Task CreatePostAsync(Post model);
        public Task DeletePostAsync(string id);
    }
}
