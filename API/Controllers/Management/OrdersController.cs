using Application.Core;
using Application.Orders;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.Management;

public class OrdersController : ManagementApiController
{
    [HttpGet]
    [SwaggerOperation(Summary = "List Orders")]
    public async Task<ActionResult<ListOrderResponseDTO>> GetOrders([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query { QueryParams = pagingParams }));
    }
}