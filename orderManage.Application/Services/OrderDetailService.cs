using orderManage.Application.Common.Interfaces;
using orderManage.Application.DTOs;
using orderManage.Domain.Entities;

namespace orderManage.Application.Services;

public class OrderDetailService
{
    private readonly IOrderDetailRepository _repo;

    public OrderDetailService(IOrderDetailRepository repo) => _repo = repo;

    public async Task Create(int id, List<OrderDetailCreateDto> orderDetailCreateDto)
    {
        List<OrderDetail> orderDetails = new();
        foreach (var od in orderDetailCreateDto)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = id,
                ProductId = od.ProductId,
                Quantity = od.Quantity,
            };
            orderDetails.Add(orderDetail);
        }

        await _repo.Create(orderDetails);
    }

    public async Task Delete(OrderDetailDeleteDto orderDetailDeleteDto)
    {
        await _repo.Delete(orderDetailDeleteDto);
    }

}