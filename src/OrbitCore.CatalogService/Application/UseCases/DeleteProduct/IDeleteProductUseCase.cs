namespace OrbitCore.CatalogService.Application.UseCases.DeleteProduct
{
    public interface IDeleteProductUseCase
    {
        Task<DeleteProductOutput?> DeleteProductAsync(string id, CancellationToken cancellationToken);
    }
}
