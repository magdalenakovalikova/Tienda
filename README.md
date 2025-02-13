# TiendaRopa
# Clean Architecture in ASP.NET Core with EF Core & CQRS

## 📌 Overview
This repository demonstrates **Clean Architecture** in **ASP.NET Core** using **EF Core, MediatR (CQRS), and Dependency Injection**.

## 🏗️ Project Structure
```plaintext
- src/
  - TiendaRopa.Api/           # UI Layer (ASP.NET Core API)
  - TiendaRopa.Application/   # Application Layer (CQRS, Business Logic)
  - TiendaRopa.Domain/        # Domain Layer (Entities, Interfaces, Business Rules)
  - TiendaRopa.Infrastructure/ # Infrastructure Layer (EF Core, Repositories, External Services)
  - TiendaRopa.Persistence/   # Persistence Layer (DB Context, Migrations)
  - TiendaRopa.Tests/         # Unit and Integration Tests
```

## 🚀 Getting Started
### 1️⃣ Clone the Repository
```sh
git clone <repository_url>
cd TiendaRopa
```

### 2️⃣ Install Dependencies
```sh
cd src/TiendaRopa.Infrastructure
# Install EF Core & other dependencies
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package FluentValidation
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

### 3️⃣ Run Migrations & Database Setup
```sh
dotnet ef migrations add InitialCreate --project src/TiendaRopa.Persistence
dotnet ef database update --project src/TiendaRopa.Persistence
```

### 4️⃣ Run the Application
```sh
dotnet run --project src/TiendaRopa.Api
```

## ✅ Features Implemented
- **EF Core Repositories** (Direct usage, No unnecessary Generic Repository)
- **CQRS using MediatR** (Separates Read/Write logic)
- **Clean Architecture** (Decoupled layers)
- **Unit Tests** for Core Services

## 🧪 Running Tests
```sh
dotnet test src/TiendaRopa.Tests
```

## 🔍 Example Unit Test
Create a unit test for `ProductService` in `TiendaRopa.Tests`:

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using TiendaRopa.Application.Commands;
using TiendaRopa.Application.Handlers;
using TiendaRopa.Domain.Entities;
using TiendaRopa.Domain.Interfaces;

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
