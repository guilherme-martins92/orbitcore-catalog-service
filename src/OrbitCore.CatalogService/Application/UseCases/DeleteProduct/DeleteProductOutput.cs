using Mapster;
using OrbitCore.CatalogService.Domain.Entities;

namespace OrbitCore.CatalogService.Application.UseCases.DeleteProduct
{
    public class DeleteProductOutput
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public static DeleteProductOutput FromEntity(Product product)
        {
            return product.Adapt<DeleteProductOutput>();
        }
    }
}
