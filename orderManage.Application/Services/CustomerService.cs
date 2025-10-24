using orderManage.Application.Common.Interfaces;
using orderManage.Application.DTOs;
using orderManage.Domain.Entities;


namespace orderManage.Application.Services;
public class CustomerService
{
    private readonly ICustomerRepository _repo;

    public CustomerService(ICustomerRepository repository) =>  _repo = repository;

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task Create(CustomerCreateDto customerDto)
    {
        var customer = new Customer()
        {
            Name = customerDto.Name,
            Email = customerDto.Email,
        };
        await _repo.Create(customer);
    }

    public async Task Update(int id, CustomerCreateDto customerDto)
    {
        var customer = new Customer()
        {
            Name = customerDto.Name,
            Email = customerDto.Email,
        };
        await _repo.Update(id, customer);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
    }
}