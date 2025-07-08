using AutoMapper;
using PcPartsShop.API.DTOs.Brands;
using PcPartsShop.API.Models;
using PcPartsShop.API.Repository.BrandRepository;

namespace PcPartsShop.API.Services.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepo;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var brands = await _brandRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
            var brand = await _brandRepo.GetByIdAsync(id);
            if (brand is null)
                throw new KeyNotFoundException($"Brand with ID {id} not found.");

            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<BrandDto> CreateAsync(CreateBrandDto dto)
        {
            var brandEntity = _mapper.Map<Brand>(dto);
            var brand = await _brandRepo.AddAsync(brandEntity);
            return _mapper.Map<BrandDto>(brand);
        }

        public async Task UpdateAsync(int id, UpdateBrandDto dto)
        {
            var brand = await _brandRepo.GetByIdAsync(id);
            if (brand is null)
                throw new KeyNotFoundException($"Brand with ID {id} not found.");

            _mapper.Map(dto, brand);
            await _brandRepo.UpdateAsync(brand);
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _brandRepo.GetByIdAsync(id);
            if (brand is null)
                throw new KeyNotFoundException($"Brand with ID {id} not found.");

            await _brandRepo.DeleteAsync(brand);
        }
    }

}
