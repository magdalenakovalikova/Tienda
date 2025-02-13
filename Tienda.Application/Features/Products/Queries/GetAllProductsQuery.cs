using MediatR;
using Tienda.Domain.Entities;

namespace Tienda.Application.Features.Products.Queries;
public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;