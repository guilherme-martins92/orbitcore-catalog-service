using FastEndpoints;
using FastEndpoints.Swagger;
using OrbitCore.CatalogService.Extensions;
using OrbitCore.CatalogService.Repositories.DynamoDB;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();
builder.Services.AddUseCases();
builder.Services.AddDynamoDB(builder.Configuration);
// Add AWS Lambda support.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Serviço de catálogo de Produtos";
        s.Version = "v1";
    };
});

var app = builder.Build();
app.UseFastEndpoints()
   .UseSwaggerGen();

app.Run();
