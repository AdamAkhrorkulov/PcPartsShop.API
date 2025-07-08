using System.Dynamic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcPartsShop.API.DTOs.Brands;
using PcPartsShop.API.Models;
using PcPartsShop.API.Repository;
using PcPartsShop.API.Services.BrandService;

namespace PcPartsShop.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;


        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAll()
        {
            return Ok(await _brandService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetById(int id)
        {
            return Ok(await _brandService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<BrandDto>> Create(CreateBrandDto dto)
        {
            var brandDto = await _brandService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id = brandDto.Id }, brandDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateBrandDto dto)
        {
            await _brandService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _brandService.DeleteAsync(id);
            return NoContent();
        }

    }
}
