using MediatR;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Application.Features.Products.Commands;
using Tienda.Domain.Interfaces;

namespace Tienda.Application.Features.Products.Handlers;
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
        }

        // Update product properties from request using the Update method
        product.Update(request.Name, request.Price, request.Size, request.Color);

        // Save changes
        await _productRepository.UpdateAsync(product);
        await _productRepository.SaveChangesAsync();

        return product.Id;
    }

}
