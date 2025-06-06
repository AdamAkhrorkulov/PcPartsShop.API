using Microsoft.EntityFrameworkCore;
using PcPartsShop.API.Data;
using PcPartsShop.API.Models;

namespace PcPartsShop.API.Repository.ProductReoisitory
{
    // 2. Implement the product repository
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetWithRelationsAsync()
        {
            return await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
        }   

        public async Task<Product> GetByIdWithRelationsAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }

}
