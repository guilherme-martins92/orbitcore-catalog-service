using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;

namespace OrbitCore.CatalogService.Repositories.DynamoDB
{
    public static class DynamoDBConfig
    {
        public static IServiceCollection AddDynamoDB(this IServiceCollection services, IConfiguration configuration)
        {
            var awsOptions = configuration.GetSection("DynamoDBConfig").Get<AWSOptions>();
            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonDynamoDB>();

            services.AddScoped<IDynamoDBContext, DynamoDBContext>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
