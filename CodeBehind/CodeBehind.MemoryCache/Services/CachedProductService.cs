using CodeBehind.MemoryCache.Models;
using CodeBehind.MemoryCache.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CodeBehind.MemoryCache.Services
{
    public class CachedProductService : IProductService
    {
        private const string ProductListCacheKey = "ProductList";
        private readonly IProductService _productService;
        private readonly IMemoryCache _cache;

        public CachedProductService(IProductService productService, IMemoryCache cache)
        {
            _productService = productService;
            _cache = cache;
        }

        public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
        {
            var options = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            if (_cache.TryGetValue(ProductListCacheKey, out List<Product> products))
            {
                return products;
            }

            products = await _productService.GetAll(cancellationToken);

            _cache.Set(ProductListCacheKey, products, options);

            return products;
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
