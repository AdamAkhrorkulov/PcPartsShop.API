using AutoMapper;
using PcPartsShop.API.DTOs.Products;
using PcPartsShop.API.Models;
using PcPartsShop.API.Repository.BrandRepository;
using PcPartsShop.API.Repository.CategoryRepository;
using PcPartsShop.API.Repository.ProductReoisitory;

namespace PcPartsShop.API.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IBrandRepository _brandRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IBrandRepository brandRepo, ICategoryRepository categoryRepo, IMapper mapper) 
        {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepo.GetAllWithDetailsAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepo.GetByIdWithDetailsAsync(id);
            if (product is null) 
                throw new KeyNotFoundException($"Product with ID {id} not found.");  

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var categoryId = await _categoryRepo.GetByIdAsync(dto.CategoryId);
            var brandId = await _brandRepo.GetByIdAsync(dto.BrandId);

            if (categoryId is null)
                throw new KeyNotFoundException("Category not Found.");

            if (brandId is null)
                throw new KeyNotFoundException("Brand not Found.");


            var productEntity = _mapper.Map<Product>(dto);

            var product = await _productRepo.AddAsync(productEntity);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product is null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            _mapper.Map(dto, product);
            await _productRepo.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id) 
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product is null)
                throw new KeyNotFoundException($"Product with {id} does not exists!");
            
            await _productRepo.DeleteAsync(product);
        }
    }
}
