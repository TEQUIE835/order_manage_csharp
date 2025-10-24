using orderManage.Domain.Entities;

namespace orderManage.Application.Common.Interfaces;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetAll();
    public Task<Order> GetById(int id);
    public Task<int> Create(Order order);
    public Task Update(int id, Order order);
    public Task  Delete(int id);
}