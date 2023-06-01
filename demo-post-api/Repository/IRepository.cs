namespace demo_post_api.Repository
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAsync();
        public Task<T> GetAsync(string id);
        public Task CreateAsync(T model);
        public Task UpdateAsync(string id, T model);
        public Task DeleteAsync(string id);
    }
}
