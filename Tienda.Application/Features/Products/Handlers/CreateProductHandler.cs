using MediatR;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Application.Features.Products.Commands;
using Tienda.Domain.Interfaces;

namespace Tienda.Application.Features.Products.Handlers;
public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price, request.Size, request.Color);
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
        return product.Id;
    }
}