using MediatR;

namespace Tienda.Application.Features.Products.Commands;
public record DeleteProductCommand(Guid Id) : IRequest<Guid>;
