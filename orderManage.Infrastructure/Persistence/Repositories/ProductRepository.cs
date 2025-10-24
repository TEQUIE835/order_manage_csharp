using Microsoft.EntityFrameworkCore;
using orderManage.Application.Common.Interfaces;
using orderManage.Domain.Entities;

namespace orderManage.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context) => _context = context;
    
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) throw new Exception("Product not found");
        return product;
    }

    public async Task Create(Product product)
    { 
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Product updatedProduct)
    {
        var product = await GetById(id);
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var product = await GetById(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}