using FluentAssertions;
using Moq;
using Tienda.Application.Features.Products.Commands;
using Tienda.Application.Features.Products.Handlers;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

namespace Tienda.Tests.Application;
public class UpdateProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldUpdateProduct_WhenProductExists()
    {
        // Arrange
        var product = new Product("Test Product", 10.0m, "M", "Red");
        var productId = product.Id;


        var repositoryMock = new Mock<IProductRepository>();
        repositoryMock.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);
        repositoryMock.Setup(r => r.UpdateAsync(product)).Returns(Task.CompletedTask);
        repositoryMock.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

        var handler = new UpdateProductHandler(repositoryMock.Object);
        var command = new UpdateProductCommand(productId, "Updated Product", 15.0m, "L", "Green");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(productId);
        repositoryMock.Verify(r => r.GetByIdAsync(productId), Times.Once);
        repositoryMock.Verify(r => r.UpdateAsync(product), Times.Once);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}