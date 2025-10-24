namespace orderManage.Application.DTOs;

public class OrderCreateDto
{
    public int CustomerId { get; set; }
    public int OrderStatusId { get; set; }
    
    public List<OrderDetailCreateDto> OrderDetails { get; set; }
}