namespace orderManage.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int OrderStatusId { get; set; }

    public Customer Customer;
    public List<OrderDetail> OrderDetails;
    public OrderStatus OrderStatus { get; set; }
}