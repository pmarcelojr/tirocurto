using CodeBehind.MemoryCache.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBehind.MemoryCache.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
