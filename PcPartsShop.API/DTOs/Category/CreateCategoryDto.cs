using System.ComponentModel.DataAnnotations;

namespace PcPartsShop.API.DTOs.Category;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100)]

    public string Name { get; set; }
}