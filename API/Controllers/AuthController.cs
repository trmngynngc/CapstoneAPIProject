using System.Security.Claims;
using API.DTOs.Accounts;
using API.Services;
using Application.Auth;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[AllowAnonymous]
[Route("api/[Controller]")]
public class AuthController : BaseApiController
{
    private readonly DataContext _context;
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;
    private readonly UserManager<User> _userManager;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager,
        TokenService tokenService, DataContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost]
    [Route("[Action]")]
    [SwaggerOperation(Summary = "Log a user in")]
    public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDto)
    {
        var user = await Mediator.Send(new Login.Query{LoginRequestDto = loginRequestDto});

        if (user == null) return Unauthorized();

        var userDto = CreateUserDto(user);
        userDto.Avatar = user.Avatar?.Url + '/' + user.Avatar?.Name + '.' + user.Avatar?.Extension;

        return userDto;
    }

    [HttpPost]
    [Route("[Action]")]
    [SwaggerOperation(Summary = "Register a user")]
    public async Task<ActionResult<LoginResponseDTO>> Register(RegisterRequestDTO registerRequestDto)
    {
        var user = await Mediator.Send(new Register.Query{RegisterRequestDto = registerRequestDto});
        if (user == null) return BadRequest("Problem registering user");
        
        return CreateUserDto(user);
    }

    [Authorize]
    [HttpGet]
    [Route("[Action]")]
    [SwaggerOperation(Summary = "Get the Current User using a login token")]
    public async Task<ActionResult<LoginResponseDTO>> GetCurrentUser()
    {
        var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
        return CreateUserDto(user);
    }

    private LoginResponseDTO CreateUserDto(User user)
    {
        var userDto = new LoginResponseDTO
        {
            Name = user.Name,
            Address = user.Address,
            UserName = user.UserName,
            Token = _tokenService.CreateToken(user),
            Email = user.Email
        };
        if (user.Avatar != null)
            userDto.Avatar = user.Avatar.Url + '/' + user.Avatar.Name + '.' + user.Avatar.Extension;

        return userDto;
    }
}