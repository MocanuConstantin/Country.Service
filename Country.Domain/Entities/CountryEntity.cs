
namespace Country.Domain.Entities;

public class CountryEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Alpha_2_Code { get; set; } = string.Empty;
}