using FluentAssertions;
using Moq;
using Tienda.Application.Features.Products.Queries;
using Tienda.Application.Features.Products.Handlers;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

namespace Tienda.Tests.Application;
public class GetAllProductsHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnAllProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product("Product 1", 10.0m, "M", "Red"),
            new Product("Product 2", 20.0m, "L", "Blue")
        };

        var repositoryMock = new Mock<IProductRepository>();
        repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

        var handler = new GetAllProductsHandler(repositoryMock.Object);
        var query = new GetAllProductsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(products);
        repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }
}