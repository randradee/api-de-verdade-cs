namespace api_de_verdade.Domain.Dtos.ProductDtos
{
    public record UpdateProductDto
        (
            string Name,
            short QuantityInPackage,
            int UnitOfMeasurement,
            int CategoryId
        );
}
