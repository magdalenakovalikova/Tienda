using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Tienda.Application.Features.Products.Commands;
using Tienda.Application.Features.Products.Handlers;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

namespace Tienda.Tests.Application
{
    public class DeleteProductHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldDeleteProduct_WhenProductExists()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product("Test Product", 10.0m, "M", "Red");

            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);
            repositoryMock.Setup(r => r.DeleteAsync(productId)).Returns(Task.CompletedTask);
            repositoryMock.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            var handler = new DeleteProductHandler(repositoryMock.Object);
            var command = new DeleteProductCommand(productId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(productId);
            repositoryMock.Verify(r => r.GetByIdAsync(productId), Times.Once);
            repositoryMock.Verify(r => r.DeleteAsync(productId), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
