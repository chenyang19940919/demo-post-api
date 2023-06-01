using demo_post_api.Models;
using demo_post_api.Repository;

namespace demo_post_api.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _repository;
        public PostService(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task CreatePostAsync(Post model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task DeletePostAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Post> GetPostAsync(string id)
        {
            var post = await _repository.GetAsync(id);
            return post;
        }

        public async Task<List<Post>> GetPostListAsync()
        {
            var posts = await _repository.GetAsync();
            return posts;
        }

        public async Task UpdatePostAsync(string id, Post model)
        {
            await _repository.UpdateAsync(id, model);
        }
    }
}
