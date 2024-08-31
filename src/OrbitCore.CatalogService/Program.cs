using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder();
builder.Services
   .AddFastEndpoints();

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "My API";
        s.Version = "v1";
    };
});

var app = builder.Build();
app.UseFastEndpoints()
   .UseSwaggerGen();

app.Run();
