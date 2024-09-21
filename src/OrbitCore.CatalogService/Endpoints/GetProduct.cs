using FastEndpoints;
using OrbitCore.CatalogService.Application.UseCases.GetProduct;

namespace OrbitCore.CatalogService.Endpoints
{
    public class GetProduct : EndpointWithoutRequest<GetProductOutput>
    {
        private IGetProductUseCase GetProductUseCase;
        public GetProduct(IGetProductUseCase getProductUseCase)
        {
            GetProductUseCase = getProductUseCase;
        }

        public override void Configure()
        {
            Get("/product/{id}");
            Summary(s =>
            {
                s.Summary = "Get a Product";
                s.Description = "Return a Product by Id";
            });

            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var productId = Route<string>("id");

                if (productId is null)
                    return;

                var product = await GetProductUseCase.GetProductByIdAsync(productId, ct);

                if (product is null)
                {
                    await SendNotFoundAsync(ct);
                    return;
                }

                await SendOkAsync(product, ct);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while getting product");
                await SendErrorsAsync(500, ct);
            }
        }
    }
}
