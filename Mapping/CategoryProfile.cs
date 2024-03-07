using api_de_verdade.Domain.Dtos;
using api_de_verdade.Domain.DTOs;
using api_de_verdade.Domain.Models;
using AutoMapper;

namespace api_de_verdade.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>()
                .ForMember(x => x.Name, opt => opt.Condition(src => src.Name != null));

            CreateMap<GetCategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>()
                .ForMember(x => x.Name, opt => opt.Condition(src => src.Name != null));

            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>()
                .ForMember(x => x.Name, opt => opt.Condition(src => src.Name != null));
        }
    }
}
