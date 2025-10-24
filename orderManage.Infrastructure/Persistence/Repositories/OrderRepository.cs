using Microsoft.EntityFrameworkCore;
using orderManage.Application.Common.Interfaces;
using orderManage.Domain.Entities;

namespace orderManage.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext  _context;
    public OrderRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
    }

    public async Task<Order> GetById(int id)
    {
        var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) throw new Exception("Order not found");
        return order;
    }

    public async Task<int> Create(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        int id = await _context.Orders.OrderByDescending(o => o.Id).Select(o => o.Id).FirstOrDefaultAsync();
        return id;
    }

    public async Task Update(int id, Order updatedOrder)
    {
        var order = await GetById(id);
        order.OrderStatusId = updatedOrder.OrderStatusId;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var order = await GetById(id);
        _context.Remove(order);
        await _context.SaveChangesAsync();
    }
}