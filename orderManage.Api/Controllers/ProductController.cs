using Microsoft.AspNetCore.Mvc;
using orderManage.Application.DTOs;
using orderManage.Application.Services;
using orderManage.Domain.Entities;

namespace orderManage.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _serv;

    public ProductController(ProductService serv) => _serv = serv;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var customers = await _serv.GetAll();
            return Ok(customers);
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
            var customer = await _serv.GetById(id);
            return Ok(customer);
        }
        catch (Exception e)
        {
            return BadRequest("Error en GetById: " + e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto product)
    {
        try
        {
            await _serv.Create(product);
            return Ok("Producto creado exitosamente");
        }
        catch (Exception e)
        {
            return BadRequest("Error en Create: " + e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductCreateDto product)
    {
        try
        {
            await _serv.Update(id, product);
            return Ok("Producto editado exitosamente");
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
            return Ok("Producto eliminado exitosamente");
        }
        catch (Exception e)
        {
            return BadRequest("Error en Delete: " + e.Message);
        }
    }
}