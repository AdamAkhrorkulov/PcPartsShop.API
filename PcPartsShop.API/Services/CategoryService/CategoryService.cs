using AutoMapper;
using PcPartsShop.API.DTOs.Category;
using PcPartsShop.API.Models;
using PcPartsShop.API.Repository.CategoryRepository;

namespace PcPartsShop.API.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category is null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var categoryEntity = _mapper.Map<Category>(dto);
            var category = await _categoryRepo.AddAsync(categoryEntity);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category is null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            _mapper.Map(dto, category);
            await _categoryRepo.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category is null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            await _categoryRepo.DeleteAsync(category);
        }
    }

}
