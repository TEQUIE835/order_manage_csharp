using Microsoft.EntityFrameworkCore;
using orderManage.Application.Common.Interfaces;
using orderManage.Domain.Entities;

namespace orderManage.Infrastructure.Persistence.Repositories;

public class OrderStatusRepository : IOrderStatusRepository
{
    private readonly AppDbContext _context;

    public OrderStatusRepository(AppDbContext context) =>  _context = context;

    public async Task<IEnumerable<OrderStatus>> GetAll()
    {
        var orderStatuses = await _context.OrderStatuses.ToListAsync();
        return orderStatuses;
    }

    public async Task<OrderStatus> GetById(int id)
    {
        var orderStatus = await _context.OrderStatuses.FindAsync(id);
        if (orderStatus == null) throw new Exception("OrderStatus not found");
        return orderStatus;
    }

    public async Task Create(OrderStatus orderStatus)
    {
        await _context.OrderStatuses.AddAsync(orderStatus);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, OrderStatus updatedOrderStatus)
    {
        var orderStatus = await GetById(id);
        orderStatus.Name = updatedOrderStatus.Name;
        orderStatus.Description = updatedOrderStatus.Description;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var orderStatus = await GetById(id);
        _context.OrderStatuses.Remove(orderStatus);
        await _context.SaveChangesAsync();
    }
}