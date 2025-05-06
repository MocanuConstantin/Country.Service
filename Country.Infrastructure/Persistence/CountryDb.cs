using Country.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Country.Infrastructure.Persistence;

public class CountryDb : DbContext
{
    public CountryDb(DbContextOptions<CountryDb> options) : base(options)
    {
    }
    public DbSet<CountryEntity> Countries { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}