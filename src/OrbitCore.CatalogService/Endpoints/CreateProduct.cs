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
            Post("/product");
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
            var output = new CreateProductOutput() { Description = input.Description, Id = Guid.NewGuid().ToString(), Price = input.Price, Name = input.Name };
            Console.WriteLine(output.Name);
            await SendOkAsync(output, ct);
        }

    }
}
