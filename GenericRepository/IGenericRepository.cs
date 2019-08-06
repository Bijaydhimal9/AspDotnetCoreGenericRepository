using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspDotnetCoreGenericRepository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
         Task CreateAsync(T t);

         Task UpdateAsync(T t);

         Task DeleteAsync(T t);

         Task<List<T>> FindAllAsync();

         Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);

         Task<T> FindSingleAsync(Expression<Func<T,bool>> predicate);
    }
}