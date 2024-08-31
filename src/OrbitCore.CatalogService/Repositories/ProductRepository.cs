using Amazon.DynamoDBv2.DataModel;
using OrbitCore.CatalogService.Domain.Entities;
using OrbitCore.CatalogService.Repositories.DynamoDB;

namespace OrbitCore.CatalogService.Repositories
{
    public class ProductRepository : DynamoDBRepository<Product>, IProductRepository
    {
        public ProductRepository(IDynamoDBContext context) : base(context)
        {
        }

        // Implementação de métodos adicionais específicos para produtos
    }
}
