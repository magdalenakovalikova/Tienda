
namespace Tienda.Application.Features.Products.Dtos;
public class ProductDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Size { get; set; }
    public required string Color { get; set; }
}
