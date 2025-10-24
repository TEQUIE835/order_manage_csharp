using Microsoft.EntityFrameworkCore;
using orderManage.Application.Common.Interfaces;
using orderManage.Domain.Entities;

namespace orderManage.Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Customer>> GetAll()
    {
        var customers = await _context.Customers.ToListAsync();
        return customers;
    }

    public async Task<Customer> GetById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) throw new Exception("Customer not found");
        return customer;
    }

    public async Task Create(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Customer updatedCustomer)
    {
        var customer = await GetById(id);
        customer.Name = updatedCustomer.Name;
        customer.Email = updatedCustomer.Email;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var customer = await GetById(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}