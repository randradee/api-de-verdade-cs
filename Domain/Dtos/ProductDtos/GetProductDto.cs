using api_de_verdade.Domain.Dtos.CategoryDtos;

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
