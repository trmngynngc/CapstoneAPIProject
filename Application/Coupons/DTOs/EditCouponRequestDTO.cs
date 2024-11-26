using System.ComponentModel.DataAnnotations;

namespace Application.Coupons;

public class EditCouponRequestDTO
{
    public string Code { get; set; }

    [Range(0.0, double.MaxValue, ErrorMessage = "Amount must be not be negative")]
    public decimal Amount { get; set; }

    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}
