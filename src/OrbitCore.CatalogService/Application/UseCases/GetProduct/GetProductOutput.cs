using Mapster;
using OrbitCore.CatalogService.Application.UseCases.CreateProduct;
using OrbitCore.CatalogService.Domain.Entities;

namespace OrbitCore.CatalogService.Application.UseCases.GetProduct
{
    public class GetProductOutput
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public static GetProductOutput FromEntity(Product product)
        {
            return product.Adapt<GetProductOutput>();
        }
    }
}
