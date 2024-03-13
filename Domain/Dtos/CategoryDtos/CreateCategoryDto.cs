using System.ComponentModel.DataAnnotations;

namespace api_de_verdade.Domain.Dtos
{
    public record CreateCategoryDto
        (
            [Required]
            [MaxLength(30)]
            string Name
        );
}
