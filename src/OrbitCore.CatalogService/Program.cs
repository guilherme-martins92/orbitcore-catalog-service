using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using OrbitCore.CatalogService.Extensions;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();
builder.Services.AddUseCases();

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Servi�o de cat�logo de Produtos";
        s.Version = "v1";
    };
});

var app = builder.Build();
app.UseFastEndpoints()
   .UseSwaggerGen();

app.Run();
