using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APDB_PJATK_CW4_s30115.Models;

[Table("PCs")]
public class PC
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public double Weight { get; set; }

    [Required]
    public int Warranty { get; set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Required]
    public int Stock { get; set; }

    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}
