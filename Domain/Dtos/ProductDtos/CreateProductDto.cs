using System.ComponentModel.DataAnnotations;

namespace api_de_verdade.Domain.Dtos.ProductDtos
{
    public record CreateProductDto(
            [Required]
            [MaxLength(50)]
            string Name,

            [Required]
            [Range(0, 100)]
            short QuantityInPackage,

            [Required]
            [Range(1, 5)]
            int UnitOfMeasurement,

            [Required]
            int CategoryId
        );
}
