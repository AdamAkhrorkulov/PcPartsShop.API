using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcPartsShop.API.Data;
using PcPartsShop.API.DTOs.Products;
using PcPartsShop.API.Models;
using PcPartsShop.API.Repository;
using PcPartsShop.API.Repository.ProductReoisitory;

namespace PcPartsShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")] 
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var allProducts = await _productRepo.GetWithRelationsAsync();

            var productDto = _mapper.Map<IEnumerable<ProductDto>>(allProducts);
            return Ok(productDto);  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productRepo.GetByIdWithRelationsAsync(id);
            if (product is null)
                return NotFound($"Product with ID {id} not found.");

            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto dto)
        {
            var productEntity = _mapper.Map<Product>(dto);  

            var product = await _productRepo.AddAsync(productEntity);

            var productDto = _mapper.Map<ProductDto>(product);
            return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductDto updateProduct)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product is null)
                return NotFound($"Product with ID {id} not found.");

            _mapper.Map(updateProduct, product);
            await _productRepo.UpdateAsync(product);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product is null)    
            {
                return NotFound($"Product with {id} does not exists!");
            }

            await _productRepo.DeleteAsync(product);
            return NoContent();
        }
    }
}
    