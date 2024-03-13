using System.ComponentModel.DataAnnotations;

namespace api_de_verdade.Domain.Dtos.CategoryDtos
{
    public record UpdateCategoryDto
        (
            [Required]
            [MaxLength(30)]
            string Name
        );
}