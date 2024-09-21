using FastEndpoints;
using OrbitCore.CatalogService.Application.UseCases.DeleteProduct;

namespace OrbitCore.CatalogService.Endpoints
{
    public class DeleteProduct : EndpointWithoutRequest<DeleteProductOutput>
    {
        private IDeleteProductUseCase DeleteProductUseCase;

        public DeleteProduct(IDeleteProductUseCase deleteProductUseCase)
        {
            DeleteProductUseCase = deleteProductUseCase;
        }

        public override void Configure()
        {
            Delete("/product/{id}");
            Summary(s =>
            {
                s.Summary = "Delete a Product";
                s.Description = "Delete a Product by Id";
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

                var product = await DeleteProductUseCase.DeleteProductAsync(productId, ct);

                if (product is null)
                {
                    await SendNotFoundAsync(ct);
                    return;
                }

                await SendOkAsync(product, ct);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting product");
                await SendErrorsAsync(500, ct);
            }
        }
    }
}
