using OrbitCore.CatalogService.Repositories;

namespace OrbitCore.CatalogService.Application.UseCases.CreateProduct
{
    public interface ICreateProductUseCase : IUseCase<CreateProductInput, CreateProductOutput>
    {

    }

    public class CreateProductUseCase : ICreateProductUseCase
    {
        public CreateProductUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public async Task<CreateProductOutput> HandleAsync(CreateProductInput input, CancellationToken ct)
        {
            var product = input.ToEntity();

            await ProductRepository.SaveAsync(product);

            return CreateProductOutput.FromEntity(product);
        }
    }
}
