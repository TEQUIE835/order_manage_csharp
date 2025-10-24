using orderManage.Application.Common.Interfaces;
using orderManage.Application.DTOs;
using orderManage.Domain.Entities;

namespace orderManage.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo) => _repo = repo;

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<Product> GetById(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task Create(ProductCreateDto productDto)
    {
        if (productDto.Price <= 0) throw new Exception("Price must be greater than zero");
        var product = new Product()
        {
            Name = productDto.Name,
            Price = productDto.Price
        };
        await _repo.Create(product);
    }

    public async Task Update(int id, ProductCreateDto productDto)
    {
        if (productDto.Price <= 0) throw new Exception("Price must be greater than zero");
        var updatedProduct = new Product()
        {
            Name = productDto.Name,
            Price = productDto.Price
        };
        await _repo.Update(id, updatedProduct);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
    }
}