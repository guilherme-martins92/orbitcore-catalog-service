
using OrbitCore.CatalogService.Repositories;

namespace OrbitCore.CatalogService.Application.UseCases.DeleteProduct
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private IProductRepository ProductRepository { get; }

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<DeleteProductOutput?> DeleteProductAsync(string id, CancellationToken cancellationToken)
        {
            var product = await ProductRepository.GetByIdAsync(id);

            if (product is null)
                return null;

            await ProductRepository.DeleteAsync(id);

            return DeleteProductOutput.FromEntity(product);
        }
    }
}
