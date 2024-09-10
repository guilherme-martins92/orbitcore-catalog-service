using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;

namespace OrbitCore.CatalogService.Repositories.DynamoDB
{
    public static class DynamoDBConfig
    {
        public static IServiceCollection AddDynamoDB(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurar Amazon DynamoDB
            var dynamoDbConfig = new AmazonDynamoDBConfig
            {
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(configuration["DynamoDBConfig:Region"])
            };

            // Adicionar AWS DynamoDB client
            services.AddSingleton<IAmazonDynamoDB>(sp => new AmazonDynamoDBClient(dynamoDbConfig));

            // Se estiver usando DynamoDBContext
            services.AddSingleton<IDynamoDBContext>(sp => new DynamoDBContext(sp.GetRequiredService<IAmazonDynamoDB>()));

            // Registrar repositórios
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
