using PcPartsShop.API.Models;

namespace PcPartsShop.API.Repository.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> ExistsByNameAsync(string name);
    }

}
