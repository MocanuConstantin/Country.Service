using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Country.Infrastructure.Persistence.Entities;

[Table("countries")]
public class CountryEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(2)]
    [Column("alpha2code")]
    public string Alpha2Code { get; set; } = string.Empty;
}