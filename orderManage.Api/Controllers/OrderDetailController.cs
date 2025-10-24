using Microsoft.AspNetCore.Mvc;
using orderManage.Application.DTOs;
using orderManage.Application.Services;

namespace orderManage.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly OrderDetailService _service;
    public OrderDetailController(OrderDetailService service) => _service = service;

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] OrderDetailDeleteDto orderDetailDeleteDto)
    {
        try
        {
            await _service.Delete(orderDetailDeleteDto);
            return Ok("Detalles eliminados con exito");
        }
        catch (Exception e)
        {
            return BadRequest("Error en Delete: " + e.Message);
        }
    }
}