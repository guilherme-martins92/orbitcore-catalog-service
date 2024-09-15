using Moq;
using OrbitCore.CatalogService.Application.UseCases.GetProduct;
using OrbitCore.CatalogService.Domain.Entities;
using OrbitCore.CatalogService.Repositories;

namespace OrbitCore.CatalogService.Tests.Application.UseCases
{
    public class GetProductUseCaseTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly GetProductUseCase getProductUseCase;

        public GetProductUseCaseTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            getProductUseCase = new GetProductUseCase(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var productId = "123";
            var product = new Product { Id = productId, Name = "Test Product" };
            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(product);

            var expectedOutput = GetProductOutput.FromEntity(product);

            // Act
            var result = await getProductUseCase.GetProductByIdAsync(productId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOutput.Id, result.Id);
            Assert.Equal(expectedOutput.Name, result.Name);

            _productRepositoryMock.Verify(repo => repo.GetByIdAsync(productId), Times.Once);

        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = "123";

#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync((Product?)null);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

            // Act
            var result = await getProductUseCase.GetProductByIdAsync(productId, CancellationToken.None);

            // Assert
            Assert.Null(result);
            _productRepositoryMock.Verify(repo => repo.GetByIdAsync(productId), Times.Once);
        }
    }
}
