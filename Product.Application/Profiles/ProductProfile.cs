using AutoMapper;
using Product.Application.Dtos;
using Product.Domain.Entities;

namespace Product.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductEntity>().ReverseMap();
        }
    }
}
