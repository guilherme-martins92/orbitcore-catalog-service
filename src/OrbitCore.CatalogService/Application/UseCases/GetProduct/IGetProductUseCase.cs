namespace OrbitCore.CatalogService.Application.UseCases.GetProduct
{
    public interface IGetProductUseCase
    {
        Task<GetProductOutput> GetProductByIdAsync(string id, CancellationToken cancellationToken);
    }
}
