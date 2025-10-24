using orderManage.Application.Common.Interfaces;
using orderManage.Application.DTOs;
using orderManage.Domain.Entities;

namespace orderManage.Infrastructure.Persistence.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly AppDbContext _context;

    public OrderDetailRepository( AppDbContext context ) =>  _context = context;

    public async Task Create(List<OrderDetail> orderDetails)
    {
        foreach (var od in orderDetails)
        {
            await _context.OrderDetails.AddAsync(od);
        }
        await _context.SaveChangesAsync();
    }

    public async Task Delete(OrderDetailDeleteDto orderDetailDeleteDto)
    {
        var orderDetail = await _context.OrderDetails
            .FindAsync(new 
                {orderDetailDeleteDto.OrderId,orderDetailDeleteDto.ProductId});
        if (orderDetail == null) throw new Exception("Order detail not found");
        _context.OrderDetails.Remove(orderDetail);
        await _context.SaveChangesAsync();
    }
}