using FluentAssertions;
using Moq;
using Tienda.Application.Features.Products.Queries;
using Tienda.Application.Features.Products.Handlers;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

namespace Tienda.Tests.Application;
public class GetProductByIdHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new Product("Test Product", 10.0m, "M", "Red");

        var repositoryMock = new Mock<IProductRepository>();
        repositoryMock.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);

        var handler = new GetProductByIdHandler(repositoryMock.Object);
        var query = new GetProductByIdQuery(productId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().Be(product);
        repositoryMock.Verify(r => r.GetByIdAsync(productId), Times.Once);
    }
}