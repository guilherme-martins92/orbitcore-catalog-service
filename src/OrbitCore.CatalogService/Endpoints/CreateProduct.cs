using FastEndpoints;
using OrbitCore.CatalogService.Application.UseCases.CreateProduct;

namespace OrbitCore.CatalogService.Endpoints
{
    public class CreateProduct : Endpoint<CreateProductInput, CreateProductOutput>
    {
        public CreateProduct(ICreateProductUseCase createProductUseCase)
        {
            CreateProductUseCase = createProductUseCase;
        }

        public override void Configure()
        {
            Post("/api/user/create");
            Summary(s =>
            {
                s.Summary = "Creates a new Product";
                s.Description = "Creates the data of a Product";
            });
            
            AllowAnonymous();
        }

        public ICreateProductUseCase CreateProductUseCase { get; }

        public override async Task HandleAsync(CreateProductInput input, CancellationToken ct)
        {
            var output = await CreateProductUseCase.HandleAsync(input, ct);
            await SendOkAsync(output, ct);
        }

    }
}
