using System.ComponentModel.DataAnnotations;

namespace api_de_verdade.Domain.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(30)]
        public String? Name { get; set; }
    }
}
