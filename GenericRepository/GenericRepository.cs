using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AspDotnetCoreGenericRepository.Data;
using Microsoft.EntityFrameworkCore;

namespace AspDotnetCoreGenericRepository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context) => this._context = context;
       
        public virtual async Task CreateAsync(T t)
        {
                await _context.Set<T>().AddAsync(t);
                await _context.SaveChangesAsync();
        }


        public virtual async Task DeleteAsync(T t)
        {
             _context.Set<T>().Remove(t);
             await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task UpdateAsync(T t)
        {
             _context.Set<T>().Update(t);
             await _context.SaveChangesAsync();
        }
    }
}