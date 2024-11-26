using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Management;

[AllowAnonymous]
[Route("api/[Controller]/Management")]
public class ManagementApiController : BaseApiController
{
}