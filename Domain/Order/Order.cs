namespace Domain.Order;

public class Order
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid? CouponId { get; set; }
    public Coupon.Coupon Coupon { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string? Note { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; } = OrderStatus.Preparing;
}
