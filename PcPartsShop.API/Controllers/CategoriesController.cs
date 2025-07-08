using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using PcPartsShop.API.DTOs.Category;
using PcPartsShop.API.Models;
using PcPartsShop.API.Repository;
using PcPartsShop.API.Services.CategoryService;

namespace PcPartsShop.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createDto)
        {
            var categoryDto = _categoryService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { Id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(int id, UpdateCategoryDto updateDto)
        {
            await _categoryService.UpdateAsync(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
