using PcPartsShop.API.DTOs.Brands;

namespace PcPartsShop.API.Services.BrandService
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllAsync();
        Task<BrandDto> GetByIdAsync(int id);
        Task<BrandDto> CreateAsync(CreateBrandDto dto);
        Task UpdateAsync(int id, UpdateBrandDto dto);
        Task DeleteAsync(int id);
    }

}
