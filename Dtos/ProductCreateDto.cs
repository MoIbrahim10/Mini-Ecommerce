using System.ComponentModel.DataAnnotations;


namespace Dtos
{
    public class ProductCreateDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(0, 9999999.99)]
        public decimal Price { get; set; }
        [Url]
        [StringLength(2083)]
        public string Image { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
    }
}
