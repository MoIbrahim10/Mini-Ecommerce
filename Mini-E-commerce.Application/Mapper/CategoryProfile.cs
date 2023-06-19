using AutoMapper;
using Dtos;
using Models;

namespace Mini_E_commerce.Application.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {


            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryCreateDto>();
        }
    }
}
