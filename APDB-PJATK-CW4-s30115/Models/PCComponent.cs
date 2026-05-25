using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APDB_PJATK_CW4_s30115.Models;

[Table("PCComponents")]
public class PCComponent
{
    public int PCId { get; set; }

    [ForeignKey(nameof(PCId))]
    public PC PC { get; set; } = null!;

    [Column(TypeName = "char(10)")]
    [MaxLength(10)]
    public string ComponentCode { get; set; } = null!;

    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;

    [Required]
    public int Amount { get; set; }
}
