using MediatR;
using Tienda.Domain.Entities;
using Tienda.Application.Features.Products.Queries;
using Tienda.Domain.Interfaces;

namespace Tienda.Application.Features.Products.Handlers;
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
        }
        return product;
    }
}