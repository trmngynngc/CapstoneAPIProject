using Application.Order.OrderDetails;
using Application.Orders;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using List = Application.Orders.OrderDetails.List;

namespace API.Controllers;

public class OrdersController : ApiController
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create an Order")]
    public async Task<IActionResult> CreateOrder(CreateOrderRequestDTO order)
    {
        return HandleResult(await Mediator.Send(new Create.Command { OrderDto = order }));

    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Edit an Order")]
    public async Task<IActionResult> EditOrder(Guid id, EditOrderRequestDTO order)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Order = order }));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "List a user's Orders")]
    public async Task<ActionResult<ListOrderResponseDTO>> GetOrders([FromQuery] ListUserOrderRequestDTO pagingParams)
    {
        return HandleResult(await Mediator.Send(new ListUserOrder.Query { QueryParams = pagingParams }));
    }
    
    [HttpGet("{id}/Details")]
    [SwaggerOperation(Summary = "List Order Details of an Order")]
    public async Task<ActionResult<ListOrderDetailResponseDTO>> GetOrderDetails(Guid id)
    {
        return HandleResult(await Mediator.Send(new List.Query { Id = id}));
    }
}
