using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcPartsShop.API.Data;
using PcPartsShop.API.Models;

namespace PcPartsShop.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }   

        public async Task<T> AddAsync(T entity)
        {
            var entityAdded = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }
            
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)        
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
