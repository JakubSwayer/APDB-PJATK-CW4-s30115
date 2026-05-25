using APDB_PJATK_CW4_s30115.DTOs;

namespace APDB_PJATK_CW4_s30115.Services;

public interface IPcService
{
    Task<IEnumerable<PcListDto>> GetAllAsync();
    Task<PcDetailsDto?> GetWithComponentsAsync(int id);
    Task<PcListDto> CreateAsync(PcCreateDto dto);
    Task<bool> UpdateAsync(int id, PcUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
