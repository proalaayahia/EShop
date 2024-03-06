using EShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } //needs to be resolved in service provider

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
