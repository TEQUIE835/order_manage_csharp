using orderManage.Domain.Entities;

namespace orderManage.Application.Common.Interfaces;

public interface ICustomerRepository
{
    
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task Create(Customer customer);
        Task Update(int id, Customer customer);
        Task Delete(int id);
    

}