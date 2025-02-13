
//GetAllProductsHandler
using MediatR;
using Tienda.Domain.Entities;
using Tienda.Application.Features.Products.Queries;
using Tienda.Domain.Interfaces;

namespace Tienda.Application.Features.Products.Handlers;
public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        return products;
    }
}