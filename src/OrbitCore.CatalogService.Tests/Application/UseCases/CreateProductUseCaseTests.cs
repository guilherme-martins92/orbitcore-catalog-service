using Moq;
using OrbitCore.CatalogService.Application.UseCases.CreateProduct;
using OrbitCore.CatalogService.Domain.Entities;
using OrbitCore.CatalogService.Repositories;

namespace OrbitCore.CatalogService.Tests.Application.UseCases
{
    public class CreateProductUseCaseTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly CreateProductUseCase createProductUseCase;

        public CreateProductUseCaseTests()
        {
            // Inicializa o mock do repositório
            _productRepositoryMock = new Mock<IProductRepository>();
            createProductUseCase = new CreateProductUseCase(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task HandleAsync_ShouldSaveProductAndReturnOutput()
        {
            // Arrange
            var input = new CreateProductInput
            {
                Name = "ProductName",
                Description = "ProductDescription",
                Price = 100
            };

            var product = input.ToEntity();

            _productRepositoryMock.Setup(repo => repo.SaveAsync(It.IsAny<Product>()))
                                  .Returns(Task.CompletedTask);

            //Act
            var result = await createProductUseCase.HandleAsync(input, CancellationToken.None);

            //Assert
            _productRepositoryMock.Verify(r => r.SaveAsync(It.Is<Product>(p => p.Name == "ProductName"
                                                                            && p.Description == "ProductDescription"
                                                                            && p.Price == 100)), Times.Once);

            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Price, result.Price);
        }
    }
}
