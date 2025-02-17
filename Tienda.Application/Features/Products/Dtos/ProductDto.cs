
namespace Tienda.Application.Features.Products.Dtos;
public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
}
