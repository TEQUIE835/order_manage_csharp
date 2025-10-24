using Microsoft.AspNetCore.Mvc;
using orderManage.Application.DTOs;
using orderManage.Application.Services;

namespace orderManage.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderStatusController : ControllerBase
{
    private readonly OrderStatusService _serv;

    public OrderStatusController(OrderStatusService serv) => _serv = serv;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var orderStatuses = await _serv.GetAll();
            return Ok(orderStatuses);
        }
        catch (Exception e)
        {
            return BadRequest("Error en GetAll: " + e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderStatusCreateDto orderStatusDto)
    {
        try
        {
            await _serv.Create(orderStatusDto);
            return Ok("Estatus creado exitosamente");
        }
        catch (Exception e)
        {
            return BadRequest("Error en Create: " + e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderStatusCreateDto orderStatusDto)
    {
        try
        {
            await _serv.Update(id, orderStatusDto);
            return Ok("Estatus actualizado exitosamente");
        }
        catch (Exception e)
        {
            return BadRequest("Error en Update: " + e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _serv.Delete(id);
            return Ok("Estatus eliminado exitosamente");
        }
        catch (Exception e)
        {
            return BadRequest("Error en Delete: " + e.Message);
        }
    }
}