using OrbitCore.CatalogService.Domain.Entities;

namespace OrbitCore.CatalogService.Application.UseCases.CreateProduct
{
    public class CreateProductInput
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }

        public Product ToEntity()
        {
            var product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Description = Description,
                Price = Price,
            };

            return product;
        }
    }
}
