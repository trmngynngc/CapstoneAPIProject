using Application.Users;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

public class UsersController : ApiController
{
    [HttpPut]
    [SwaggerOperation(Summary = "Update a user's profile")]
    public async Task<IActionResult> UpdateBio([FromBody] string bio)
    {
        return HandleResult(await Mediator.Send(new EditBio.Command { Bio = bio }));
    }
}