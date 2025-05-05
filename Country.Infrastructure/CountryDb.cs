using Microsoft.EntityFrameworkCore;
using Country.Domain.Entities;

namespace Country.Infrastructure;

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