using AspDotnetCoreGenericRepository.Data;
using AspDotnetCoreGenericRepository.GenericRepository;
using AspDotnetCoreGenericRepository.Models;

namespace AspDotnetCoreGenericRepository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}