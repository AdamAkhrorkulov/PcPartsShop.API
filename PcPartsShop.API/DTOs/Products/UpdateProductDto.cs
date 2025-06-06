using System.ComponentModel.DataAnnotations;

namespace PcPartsShop.API.DTOs.Products
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0.01, 100000)]
        public decimal Price { get; set; }


        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }
    }

}
