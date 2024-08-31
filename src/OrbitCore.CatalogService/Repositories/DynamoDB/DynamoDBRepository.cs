using Amazon.DynamoDBv2.DataModel;

namespace OrbitCore.CatalogService.Repositories.DynamoDB
{
    public class DynamoDBRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDynamoDBContext _context;

        public DynamoDBRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.LoadAsync<T>(id);
        }

        public async Task SaveAsync(T entity)
        {
            await _context.SaveAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                await _context.DeleteAsync(entity);
            }
        }
    }
}
