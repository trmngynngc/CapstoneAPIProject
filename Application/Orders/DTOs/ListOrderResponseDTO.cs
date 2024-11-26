using Application.Core;

namespace Application.Orders;

public class ListOrderResponseDTO : PagedList<Domain.Order.Order>
{
}
