namespace orderManage.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }

    public List<OrderDetail> Orders { get; set; }
}