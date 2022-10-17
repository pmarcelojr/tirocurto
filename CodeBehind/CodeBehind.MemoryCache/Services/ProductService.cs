using CodeBehind.MemoryCache.Models;
using CodeBehind.MemoryCache.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using CodeBehind.MemoryCache.Repositories;

namespace CodeBehind.MemoryCache.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMemoryCache _cache;

        public ProductService(DataContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Product
                .OrderBy(p => p.Name)
                .ToListAsync(cancellationToken);
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
