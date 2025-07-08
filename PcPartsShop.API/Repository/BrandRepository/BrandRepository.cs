using Microsoft.EntityFrameworkCore;
using PcPartsShop.API.Data;
using PcPartsShop.API.Models;

namespace PcPartsShop.API.Repository.BrandRepository
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Brands.AnyAsync(b => b.Name.ToLower() == name.ToLower());
        }
    }

}
