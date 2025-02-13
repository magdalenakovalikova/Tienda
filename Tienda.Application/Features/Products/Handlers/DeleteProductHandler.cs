using MediatR;
using Tienda.Application.Features.Products.Commands;
using Tienda.Domain.Interfaces;

namespace Tienda.Application.Features.Products.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            await _productRepository.DeleteAsync(request.Id);
            await _productRepository.SaveChangesAsync();

            return request.Id;
        }
    }
}
