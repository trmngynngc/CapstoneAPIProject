using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Stat;

[AllowAnonymous]
[Route("api/[Controller]/stat")]
public class StatApiController : BaseApiController
{
}