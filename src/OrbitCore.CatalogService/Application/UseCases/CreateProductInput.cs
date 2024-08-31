﻿namespace OrbitCore.CatalogService.Application.UseCases
{
    public class CreateProductInput
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
    }
}
