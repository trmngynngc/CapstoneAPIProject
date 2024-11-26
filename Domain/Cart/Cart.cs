using System.ComponentModel.DataAnnotations;

namespace Domain.Cart;

public class Cart
{
    [Key]
    public string UserId { get; set; }
}
