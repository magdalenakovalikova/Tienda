using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tienda.Persistence;
using Xunit;

public class DatabaseConnectionTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public void CanConnectToDatabase()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<TiendaDbContext>();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);

        // Act
        using (var context = new TiendaDbContext(optionsBuilder.Options))
        {
            // Assert
            context.Database.CanConnect().Should().BeTrue();
        }
    }
}