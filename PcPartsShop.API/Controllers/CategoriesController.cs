using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using PcPartsShop.API.DTOs.Category;
using PcPartsShop.API.Models;
using PcPartsShop.API.Repository;

namespace PcPartsShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var allCategories = await _categoryRepository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<CategoryDto>>(allCategories);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<CategoryDto>(category);
            return Ok(dto);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createDto)
        {
            var category = _mapper.Map<Category>(createDto);
            var addedCategory = await _categoryRepository.AddAsync(category);

            var categoryDto = _mapper.Map<CategoryDto>(addedCategory);
            return CreatedAtAction(nameof(GetById), new { Id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(int id, UpdateCategoryDto updateDto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDto, category);
            await _categoryRepository.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryRepository.DeleteAsync(category);
            return NoContent();
        }
    }
}
