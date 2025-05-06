namespace Country.Infrastructure.Persistence.Entities;

public class CountryEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Alpha2Code { get; set; } = string.Empty;
}