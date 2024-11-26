using System.ComponentModel.DataAnnotations;

namespace Application.Cart.CartDetails;

public class CreateCartDetailRequestDTO
{
    public Guid ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be > 0")]
    public int Quantity { get; set; }
}
