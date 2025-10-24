using orderManage.Domain.Entities;

namespace orderManage.Application.Common.Interfaces;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAll();
    public Task<Product> GetById(int id);
    public Task Create(Product product);
    public Task Update(int id, Product product);
    public Task Delete(int id);
}