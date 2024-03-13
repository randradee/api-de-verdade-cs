using api_de_verdade.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_de_verdade.Domain.Dtos.ProductDtos
{
    public record UpdateProductDto
        (
            [Required]
            [MaxLength(50)]
            string Name,

            [Required]
            [Range(0, 100)]
            short QuantityInPackage,

            [Required]
            EUnitOfMeasurement UnitOfMeasurement,

            [Required]
            int CategoryId
        );
}
