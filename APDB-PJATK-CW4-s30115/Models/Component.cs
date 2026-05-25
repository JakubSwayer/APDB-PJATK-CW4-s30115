using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APDB_PJATK_CW4_s30115.Models;

[Table("Components")]
public class Component
{
    [Key]
    [Column(TypeName = "char(10)")]
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public int ComponentManufacturersId { get; set; }

    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturer Manufacturer { get; set; } = null!;

    [Required]
    public int ComponentTypesId { get; set; }

    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentType Type { get; set; } = null!;

    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}
