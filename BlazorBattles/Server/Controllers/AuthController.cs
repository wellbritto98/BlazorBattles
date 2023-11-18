using BlazorBattles.Server.Data;
using BlazorBattles.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBattles.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    // GET
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegister request)
    {
        var response = await _authRepository.Register(
            new User
            {
                Email = request.Email,
                Bananas = request.Bananas,
                DateOfBirth = request.DateOfBirth,
                IsConfirmed = request.IsConfirmed,
            }, request.UserPassword);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLogin request)
    {
        var response = await _authRepository.Login(request.Email, request.Password);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}


