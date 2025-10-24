using orderManage.Application.DTOs;
using orderManage.Domain.Entities;

namespace orderManage.Application.Common.Interfaces;

public interface IOrderDetailRepository
{
    public Task Create(List<OrderDetail> orderDetails);
    public Task Delete(OrderDetailDeleteDto orderDetailDeleteDto);
}