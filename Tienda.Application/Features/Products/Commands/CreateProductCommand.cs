using MediatR;

namespace Tienda.Application.Features.Products.Commands;
public record CreateProductCommand(string Name, decimal Price, string Size, string Color) : IRequest<Guid>;