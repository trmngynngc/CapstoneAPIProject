namespace Domain.Order;

public class OrderDetail
{
    public Guid OrderId { get; set; }
    public Order Order  { get; set; }

    public Guid ProductId { get; set; }
    public Product.Product Product { get; set; }

    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
