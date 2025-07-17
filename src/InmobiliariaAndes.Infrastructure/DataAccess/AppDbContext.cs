using System.Diagnostics.CodeAnalysis;
using InmobiliariaAndes.Domain.Entities;
using InmobiliariaAndes.Infrastructure.DataAccess.DbMappings;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaAndes.Infrastructure.DataAccess;

[ExcludeFromCodeCoverage]
public class AppDbContext : DbContext
{

    public DbSet<Member> Members { get; set; }
    public DbSet<BalanceMovement> BalanceMovements { get; set; }
    public DbSet<Concept> Concepts { get; set; }
    public DbSet<QuartzConfiguration> QuartzConfigurations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure entities here
        ConceptDbMapping.Map(modelBuilder);
        BalanceMovementDbMapping.Map(modelBuilder);
        MemberDbMapping.Map(modelBuilder);
        QuartzConfigurationDbMapping.Map(modelBuilder);
    }
}
