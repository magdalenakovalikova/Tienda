using Moq;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;
using Tienda.Application.Features.Products.Commands;
using Tienda.Application.Features.Products.Handlers;

namespace Tienda.Tests.Application;
public class CreateProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateProduct_WhenDataIsValid()
    {
        // Arrange
        var repositoryMock = new Mock<IProductRepository>();
        var handler = new CreateProductHandler(repositoryMock.Object);
        var command = new CreateProductCommand("Camiseta", 29.99m, "M", "Rojo");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        repositoryMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        Assert.NotEqual(Guid.Empty, result);
    }
}
