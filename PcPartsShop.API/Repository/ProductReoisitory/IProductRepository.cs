using PcPartsShop.API.Models;

namespace PcPartsShop.API.Repository.ProductReoisitory
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetByIdWithRelationsAsync(int id);
        Task<IEnumerable<Product>> GetWithRelationsAsync();
    }
}
