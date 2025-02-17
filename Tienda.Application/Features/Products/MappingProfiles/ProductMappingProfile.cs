using AutoMapper;
using Tienda.Domain.Entities;
using Tienda.Application.Features.Products.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Tienda.Application.Features.Products.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
