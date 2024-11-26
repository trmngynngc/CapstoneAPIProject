using Application.Cart.CartDetails;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

public class CartsController : ApiController
{
    [HttpGet("Details")]
    [SwaggerOperation(Summary = "List Cart Details of a User")]
    public async Task<ActionResult<ListCartDetailResponseDTO>> GetCartDetails([FromQuery] ListCartDetailRequestDTO pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query { QueryParams = pagingParams }));
    }
    
    [HttpGet("Count")]
    [SwaggerOperation(Summary = "Count Cart Details of a User")]
    public async Task<ActionResult<CountCartDetailResponseDTO>> CountCartDetails()
    {
        return HandleResult(await Mediator.Send(new Count.Query()));
    }
    
    [HttpPost("Details")]
    [SwaggerOperation(Summary = "Create a Cart Details")]
    public async Task<IActionResult> CreateCartDetail(CreateCartDetailRequestDTO cartDetail)
    {
        return HandleResult(await Mediator.Send(new Create.Command { CartDetails = cartDetail }));
    }
    [HttpPut("Details")]
    [SwaggerOperation(Summary = "Edit a Cart Details")]
    public async Task<IActionResult> Edit(EditCartDetailRequestDTO cartDetail)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { CartDetails = cartDetail }));
    }

    [HttpDelete("Details")]
    [SwaggerOperation(Summary = "Delete a Cart Details")]
    public async Task<IActionResult> DeleteCartDetail(DeleteCartDetailRequestDTO cartDetails)
    {
        return HandleResult(await Mediator.Send((new Delete.Command {CartDetails = cartDetails})));
    }
}
