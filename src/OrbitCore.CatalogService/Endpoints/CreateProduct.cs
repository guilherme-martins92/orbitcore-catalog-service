using FastEndpoints;
using OrbitCore.CatalogService.Application.UseCases;

namespace OrbitCore.CatalogService.Endpoints
{
    public class CreateProduct : Endpoint<CreateProductInput, CreateProductOutput>
    {
        public CreateProduct()
        {
        }

        public override void Configure()
        {
            Post("/api/user/create");
            Summary(s =>
            {
                s.Summary = "Creates a new Product";
                s.Description = "Creates the data of a Product";
            });
            //Description(s =>);
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateProductInput input, CancellationToken ct)
        {
            await SendAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
            });
        }

    }
}
