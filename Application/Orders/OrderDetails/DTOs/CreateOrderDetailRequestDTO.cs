using System.ComponentModel.DataAnnotations;

namespace Application.Order.OrderDetails;

public class CreateOrderDetailRequestDTO
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be > 0")]
    public int Quantity { get; set; }
}
