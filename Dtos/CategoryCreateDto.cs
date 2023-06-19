using System.ComponentModel.DataAnnotations;


namespace Dtos
{
    public class CategoryCreateDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
