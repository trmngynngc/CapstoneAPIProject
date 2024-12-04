namespace Domain.Coupon;

public class Coupon
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}
