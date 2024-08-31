using OrbitCore.CatalogService.Application.UseCases.CreateProduct;

namespace OrbitCore.CatalogService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();

            return services;
        }
    }
}
