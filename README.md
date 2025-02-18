# Tienda
# Clean Architecture in ASP.NET Core with EF Core & CQRS

## 📌 Overview
This repository demonstrates **Clean Architecture** in **ASP.NET Core** using **EF Core, MediatR (CQRS), and Dependency Injection**.

## 🏗️ Project Structure
```plaintext
- 
  - Tienda.Api/           # UI Layer (ASP.NET Core API)
  - Tienda.App/           # Blazor WebAssembly SPA that consumes the API
  - Tienda.Application/   # Application Layer (CQRS, Business Logic)
  - Tienda.Domain/        # Domain Layer (Entities, Interfaces, Business Rules)
  - Tienda.Infrastructure/ # Infrastructure Layer (EF Core, Repositories, External Services)
  - Tienda.Persistence/   # Persistence Layer (DB Context, Migrations)
  - Tienda.Shared/        # Shared Library (for Models)
  - Tienda.Tests/         # Unit and Integration Tests
```

## 🚀 Getting Started
### 1️⃣ Clone the Repository
```sh
git clone https://github.com/magdalenakovalikova/Tienda.git
cd Tienda
```

### 2️⃣ Install Dependencies
```sh
cd Tienda.Infrastructure
# Install EF Core & other dependencies
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package FluentValidation
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

### 3️⃣ Run Migrations & Database Setup
```sh
dotnet ef migrations add InitialCreate --project Tienda.Persistence
dotnet ef database update --project Tienda.Persistence
```

### 4️⃣ Run the Application
```sh
dotnet run --project Tienda.Api
```

## ✅ Features Implemented
- **EF Core Repositories** (Direct usage, No unnecessary Generic Repository)
- **CQRS using MediatR** (Separates Read/Write logic)
- **Clean Architecture** (Decoupled layers)
- **Unit Tests** for Core Services

## 🧪 Running Tests
```sh
dotnet test Tienda.Tests
```

## 🔍 Example Unit Test
Create a unit test for `ProductService` in `Tienda.Tests`:

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Tienda.Application.Commands;
using Tienda.Application.Handlers;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;

public class CrearProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateProduct_WhenDataIsValid()
    {
        // Arrange
        var repositoryMock = new Mock<IProductRepository>();
        var handler = new CrearProductHandler(repositoryMock.Object);
        var command = new CrearProductCommand("Camiseta", 29.99m, "M", "Rojo");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        repositoryMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        Assert.NotEqual(Guid.Empty, result);
    }
}
```

---
This repo is structured to provide a clean, maintainable, and scalable approach to .NET Core API development. 🚀
