using MediatR;

namespace Tienda.Application.Features.Products.Commands;
public record UpdateProductCommand(Guid Id, string Name, decimal Price, string Size, string Color) : IRequest<Guid>;