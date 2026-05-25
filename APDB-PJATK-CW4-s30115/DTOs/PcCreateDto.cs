using System.ComponentModel.DataAnnotations;

namespace APDB_PJATK_CW4_s30115.DTOs;

public class PcCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public double Weight { get; set; }

    [Required]
    public int Warranty { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public int Stock { get; set; }
}
