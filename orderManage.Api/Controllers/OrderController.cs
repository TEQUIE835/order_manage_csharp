using Microsoft.AspNetCore.Mvc;
using orderManage.Application.DTOs;
using orderManage.Application.Services;
using orderManage.Domain.Entities;

namespace orderManage.Api.Controllers;

[ApiController]
[Route("[controller")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderServ;
    private readonly OrderDetailService _orderDetailServ;

    public OrderController(OrderService serv, OrderDetailService orderDetailServ)
    {
        _orderServ = serv;
        _orderDetailServ = orderDetailServ;
    } 

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        { 
            var orders = await _orderServ.GetAll();
            return Ok(orders);
        }
        catch (Exception e)
        {
            return BadRequest("Error en GetAll: " + e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var order = await _orderServ.GetById(id);
            return Ok(order);
        }
        catch (Exception e)
        {
            return BadRequest("Error en GetById: " + e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderCreateDto order)
    {
        try
        {
            var id = await _orderServ.Create(order);
            await _orderDetailServ.Create(id, order.OrderDetails);
            return Ok("Orden creada con exito");
        }
        catch (Exception e)
        {
            return BadRequest("Error en Create: " + e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderCreateDto orderCreateDto)
    {
        try
        {
            await _orderServ.Update(id, orderCreateDto);
            return Ok("Orden actualisada con exito");
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
            await _orderServ.Delete(id);
            return Ok("Orden eliminada con exito");
        }
        catch (Exception e)
        {
            return BadRequest("Error en Delete: " + e.Message);
        }
    }
}