using System.Dynamic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcPartsShop.API.DTOs.Brands;
using PcPartsShop.API.Models;
using PcPartsShop.API.Repository;

namespace PcPartsShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public BrandsController(IGenericRepository<Brand> brandRepository,IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAll()
        {
            var brands = await _brandRepository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetById(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
                return NotFound();

            var dto = _mapper.Map<BrandDto>(brand);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<BrandDto>> Create(CreateBrandDto dto)
        {
            var brand = _mapper.Map<Brand>(dto);
            var created = await _brandRepository.AddAsync(brand);
            var brandDto = _mapper.Map<BrandDto>(brand);
            return CreatedAtAction(nameof(GetById), new { Id = brandDto.Id }, brandDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateBrandDto dto)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, brand);
            await _brandRepository.UpdateAsync(brand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
                return NotFound();

            await _brandRepository.DeleteAsync(brand);
            return NoContent();
        }

    }
}
