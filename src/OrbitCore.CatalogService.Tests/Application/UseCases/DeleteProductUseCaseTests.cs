using Moq;
using OrbitCore.CatalogService.Application.UseCases.DeleteProduct;
using OrbitCore.CatalogService.Domain.Entities;
using OrbitCore.CatalogService.Repositories;

namespace OrbitCore.CatalogService.Tests.Application.UseCases
{
    public class DeleteProductUseCaseTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly DeleteProductUseCase deleteProductUseCase;

        public DeleteProductUseCaseTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            deleteProductUseCase = new DeleteProductUseCase(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task DeleteProductAsync_ProductExists_ReturnsDeleteProductOutput()
        {
            // Arrange
            var productId = "123";
            var product = new Product { Id = productId, Name = "Test Product" };
            var cancellationToken = CancellationToken.None;

            _productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(productId))
                .ReturnsAsync(product);

            _productRepositoryMock
                .Setup(repo => repo.DeleteAsync(productId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await deleteProductUseCase.DeleteProductAsync(productId, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Id);
            _productRepositoryMock.Verify(repo => repo.GetByIdAsync(productId), Times.Once);
            _productRepositoryMock.Verify(repo => repo.DeleteAsync(productId), Times.Once);
        }

        [Fact]
        public async Task DeleteProductAsync_ProductDoesNotExist_ReturnsNull()
        {
            // Arrange
            var productId = "123";
            var cancellationToken = CancellationToken.None;

            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(productId))
                .ReturnsAsync((Product)null!);

            // Act
            var result = await deleteProductUseCase.DeleteProductAsync(productId, cancellationToken);

            // Assert
            Assert.Null(result);
            _productRepositoryMock.Verify(repo => repo.GetByIdAsync(productId), Times.Once);
            _productRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
