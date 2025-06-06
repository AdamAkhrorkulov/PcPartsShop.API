using System.ComponentModel.DataAnnotations;

namespace PcPartsShop.API.DTOs.Brands;

public class UpdateBrandDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100)]
    public string Name { get; set; }
}