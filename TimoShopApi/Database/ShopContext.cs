using Microsoft.EntityFrameworkCore;
using TimoShopApi.Models;

namespace TimoShopApi.Database
{
    public class ShopContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ShopContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration["Database:ConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
