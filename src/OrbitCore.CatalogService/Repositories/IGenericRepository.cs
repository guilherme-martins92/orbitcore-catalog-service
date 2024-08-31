namespace OrbitCore.CatalogService.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task SaveAsync(T entity);
        Task DeleteAsync(string id);
    }
}
