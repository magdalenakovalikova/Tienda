﻿using FluentAssertions;
using Tienda.Domain.Entities;

namespace Tienda.Tests.Domain;
public class ProductTests
{
    [Fact]
    public void CreateProduct_WithNegativePrice_ShouldThrowException()
    {
        // Arrange & Act
        Action act = static () => new Product("Shirt", -10, "Red", "M");

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Price must be positive");
    }
}