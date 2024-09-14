using FastEndpoints;
using OrbitCore.CatalogService.Application.UseCases.CreateProduct;

namespace OrbitCore.CatalogService.Endpoints
{
    public class CreateProduct : Endpoint<CreateProductInput, CreateProductOutput>
    {
        public ICreateProductUseCase CreateProductUseCase { get; }

        public CreateProduct(ICreateProductUseCase createProductUseCase)
        {
            CreateProductUseCase = createProductUseCase;
        }

        public override void Configure()
        {
            Post("/product");
            Summary(s =>
            {
                s.Summary = "Creates a new Product";
                s.Description = "Creates the data of a Product";
            });

            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateProductInput input, CancellationToken ct)
        {
            try
            {
                var output = await CreateProductUseCase.HandleAsync(input, ct);
                await SendOkAsync(output, ct);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while creating product");
                await SendErrorsAsync(500, ct);
            }
        }
    }
}
