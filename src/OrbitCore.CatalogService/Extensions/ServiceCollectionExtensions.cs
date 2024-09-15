using OrbitCore.CatalogService.Application.UseCases.CreateProduct;
using OrbitCore.CatalogService.Application.UseCases.GetProduct;

namespace OrbitCore.CatalogService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.AddScoped<IGetProductUseCase, GetProductUseCase>();

            return services;
        }
    }
}
