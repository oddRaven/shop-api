using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TimoShopApi.Configurations;
using TimoShopApi.Models;

namespace TimoShopApi.Database;

public class ShopContext : DbContext
{
    private readonly IOptions<DatabaseConfiguration> _databaseConfigurationOptions;

    public ShopContext(IOptions<DatabaseConfiguration> databaseConfigurationOptions)
    {
        _databaseConfigurationOptions = databaseConfigurationOptions;
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _databaseConfigurationOptions.Value.ConnectionString;
        optionsBuilder.UseSqlServer(connectionString);
    }
}
