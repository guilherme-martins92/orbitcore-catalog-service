namespace OrbitCore.CatalogService.Application.UseCases.CreateProduct
{
    public interface ICreateProductUseCase : IUseCase<CreateProductInput, CreateProductOutput>
    {

    }

    public class CreateProductUseCase : ICreateProductUseCase
    {
        public async Task<CreateProductOutput> HandleAsync(CreateProductInput input,CancellationToken ct)
        {
            return new CreateProductOutput() { Id = "1234", Name = input.Name, Description = input.Description, Price = input.Price };
        }
    }
}
