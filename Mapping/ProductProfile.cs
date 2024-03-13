using api_de_verdade.Domain.Dtos.ProductDtos;
using api_de_verdade.Domain.Models;
using api_de_verdade.Extensions;
using AutoMapper;

namespace api_de_verdade.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductDto>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()))
                .ReverseMap();
        }
    }
}
