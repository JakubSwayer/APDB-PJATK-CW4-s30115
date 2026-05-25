using APDB_PJATK_CW4_s30115.DTOs;
using APDB_PJATK_CW4_s30115.Services;
using Microsoft.AspNetCore.Mvc;

namespace APDB_PJATK_CW4_s30115.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IPcService _service;

    public PcsController(IPcService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PcListDto>>> GetAll()
    {
        var pcs = await _service.GetAllAsync();
        return Ok(pcs);
    }

    [HttpGet("{id:int}/components")]
    public async Task<ActionResult<PcDetailsDto>> GetWithComponents(int id)
    {
        var pc = await _service.GetWithComponentsAsync(id);
        if (pc == null) return NotFound();
        return Ok(pc);
    }

    [HttpPost]
    public async Task<ActionResult<PcListDto>> Create([FromBody] PcCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetWithComponents), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PcUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
