using CodeBehind.MemoryCache.Models;

namespace CodeBehind.MemoryCache.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Task<List<Product>> GetAll(CancellationToken cancellationToken);
    }
}
