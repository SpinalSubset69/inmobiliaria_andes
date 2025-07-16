using Microsoft.EntityFrameworkCore;

namespace InmobiliariaAndes.Infrastructure.DataAccess;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure your entities here
        // Example: modelBuilder.Entity<YourEntity>().ToTable("YourTableName");
    }
}
