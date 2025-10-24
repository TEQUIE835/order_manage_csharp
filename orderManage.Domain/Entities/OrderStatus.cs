namespace orderManage.Domain.Entities;

public class OrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    
    public List<Order> Orders;
}