using orderManage.Application.Common.Interfaces;
using orderManage.Application.DTOs;
using orderManage.Domain.Entities;

namespace orderManage.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _repo;

    public OrderService(IOrderRepository repo) =>  _repo = repo;

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Order> GetById(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task<int> Create(OrderCreateDto orderCreateDto)
    {
        var order = new Order
        {
            CustomerId = orderCreateDto.CustomerId,
            OrderStatusId = orderCreateDto.OrderStatusId,
        };
        var id = await _repo.Create(order);
        return id;
    }

    public async Task Update(int id, OrderCreateDto orderCreateDto)
    {
        var order = new Order
        {
            CustomerId = orderCreateDto.CustomerId,
            OrderStatusId = orderCreateDto.OrderStatusId,
        };
        await _repo.Update(id,  order);
    }

    public async Task Delete(int id)
    {
        await  _repo.Delete(id);
    }
}