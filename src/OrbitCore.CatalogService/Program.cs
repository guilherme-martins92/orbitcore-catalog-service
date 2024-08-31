using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument();

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Serviço de catálogo de produtos";
        s.Version = "v1";
    };
});

var app = builder.Build();

app.UseFastEndpoints()
   .UseSwaggerGen();

app.Run();
