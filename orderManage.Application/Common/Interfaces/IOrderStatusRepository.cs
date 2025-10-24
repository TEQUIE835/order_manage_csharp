using orderManage.Domain.Entities;

namespace orderManage.Application.Common.Interfaces;

public interface IOrderStatusRepository
{
    public Task<IEnumerable<OrderStatus>> GetAll();
    public Task Create(OrderStatus orderStatus);
    public Task Update(int id, OrderStatus orderStatus);
    public Task Delete(int id);
}