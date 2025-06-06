using System.ComponentModel.DataAnnotations;

namespace PcPartsShop.API.DTOs.Products
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Name is Required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Range(0.01, 100000, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "BrandId is required.")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }
    }

}
