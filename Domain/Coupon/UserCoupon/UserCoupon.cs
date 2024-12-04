namespace Domain.Coupon;

public class UserCoupon
{
    public string UserId { get; set; }
    public User User { get; set; }

    public Guid CouponId { get; set; }
    public Coupon Coupon { get; set; }
}
