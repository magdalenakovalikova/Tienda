using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tienda.Domain.Entities;
using Tienda.Domain.Interfaces;
using Tienda.Persistence;

namespace Tienda.Infrastructure.Repositories;

public class ProductRepository(TiendaDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(Guid id) =>
        await context.Products.FindAsync(id);

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await context.Products.ToListAsync();

    public async Task AddAsync(Product product) =>
        await context.Products.AddAsync(product);

    public Task UpdateAsync(Product product)
    {
        context.Products.Update(product);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product is not null)
            context.Products.Remove(product);
    }

    public async Task SaveChangesAsync() =>
        await context.SaveChangesAsync();
}
