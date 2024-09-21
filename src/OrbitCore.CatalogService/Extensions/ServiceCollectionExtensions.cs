using OrbitCore.CatalogService.Application.UseCases.CreateProduct;
using OrbitCore.CatalogService.Application.UseCases.DeleteProduct;
using OrbitCore.CatalogService.Application.UseCases.GetProduct;

namespace OrbitCore.CatalogService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.AddScoped<IGetProductUseCase, GetProductUseCase>();
            services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();

            return services;
        }
    }
}
