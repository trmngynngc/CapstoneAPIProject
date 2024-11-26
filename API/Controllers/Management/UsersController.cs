using Application.Users;
using Application.Users.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.Management;

public class UsersController : ManagementApiController
{
    [HttpGet]
    [SwaggerOperation(Summary = "List Users")]
    public async Task<ActionResult<ListUserResponseDTO>> GetCoupons()
    {
        return HandleResult(await Mediator.Send(new List.Query {}));
    }
}
