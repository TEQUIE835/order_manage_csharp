using orderManage.Application.Common.Interfaces;
using orderManage.Application.DTOs;
using orderManage.Domain.Entities;

namespace orderManage.Application.Services;

public class OrderStatusService
{
    private readonly IOrderStatusRepository _repo;

    public OrderStatusService(IOrderStatusRepository repo) => _repo = repo;

    public async Task<IEnumerable<OrderStatus>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task Create(OrderStatusCreateDto orderStatusDto)
    {
        var orderStatus = new OrderStatus
        {
            Name = orderStatusDto.Name,
            Description = orderStatusDto.Description,
        };
        await _repo.Create(orderStatus);
    }

    public async Task Update(int id, OrderStatusCreateDto orderStatusDto)
    {
        var updatedOrderStatus = new OrderStatus
        {
            Name = orderStatusDto.Name,
            Description = orderStatusDto.Description,
        };
        await _repo.Update(id, updatedOrderStatus);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
    }
}