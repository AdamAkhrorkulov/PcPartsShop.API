using PcPartsShop.API.Models;

namespace PcPartsShop.API.Repository.BrandRepository
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<bool> ExistsByNameAsync(string name);
    }

}
