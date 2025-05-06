using Country.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Country.Infrastructure.Persistence;

public class CountryDb : DbContext
{
    public DbSet<CountryEntity> Countries { get; set; } = null!;

    public CountryDb(DbContextOptions<CountryDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}