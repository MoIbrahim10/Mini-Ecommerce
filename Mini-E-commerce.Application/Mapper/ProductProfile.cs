using AutoMapper;
using Dtos;
using Models;

namespace Mini_E_commerce.Application.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductCreateDto>();
        }
    }
}
