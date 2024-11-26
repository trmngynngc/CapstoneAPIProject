namespace Application.Orders;

public class CreateOrderRequestDTO
{
    public OrderDto Order { get; set; }
    public List<OrderDetailDto> ProductList { get; set; }

    public class OrderDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public Guid? CouponId { get; set; }
    }

    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
