namespace APDB_PJATK_CW4_s30115.DTOs;

public class ComponentManufacturerDto
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime FoundationDate { get; set; }
}
