using MediatR;
using Tienda.Domain.Entities;

namespace Tienda.Application.Features.Products.Queries;
public record GetProductByIdQuery(Guid Id) : IRequest<Product>;