using api_de_verdade.Domain.Dtos.CategoryDtos;
using api_de_verdade.Domain.Models.Enums;

namespace api_de_verdade.Domain.Dtos.ProductDtos
{
    public record GetProductDto(

        int Id,
        string Name,
        short QuantityInPackage,
        string UnitOfMeasurement,
        int CategoryId,
        GetCategoryDto Category

        );
}
