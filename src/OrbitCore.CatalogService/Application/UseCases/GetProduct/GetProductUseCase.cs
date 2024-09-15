
using OrbitCore.CatalogService.Repositories;

namespace OrbitCore.CatalogService.Application.UseCases.GetProduct
{
    public class GetProductUseCase : IGetProductUseCase
    {
        public IProductRepository ProductRepository { get; }
        public GetProductUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<GetProductOutput> GetProductByIdAsync(string id, CancellationToken cancellationToken)
        {
            var product = await ProductRepository.GetByIdAsync(id);

            var output = GetProductOutput.FromEntity(product);

            return output;
        }
    }
}
