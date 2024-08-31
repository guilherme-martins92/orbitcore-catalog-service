using Amazon.DynamoDBv2.DataModel;

namespace OrbitCore.CatalogService.Domain.Entities
{
    [DynamoDBTable("OrbitCoreProductTable")]
    public class Product
    {
        [DynamoDBHashKey]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
