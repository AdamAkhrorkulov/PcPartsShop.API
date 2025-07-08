using PcPartsShop.API.Models;

namespace PcPartsShop.API.Repository.ProductReoisitory
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithDetailsAsync();
        Task<Product> GetByIdWithDetailsAsync(int id);
    }
}
    