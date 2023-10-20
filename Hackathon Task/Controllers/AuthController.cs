using Hackathon_Task.Data.DTO;
using Hackathon_Task.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Task.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenRepository _tokenRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(ITokenRepository tokenRepository, UserManager<IdentityUser> userManager)
    {
        _tokenRepository = tokenRepository;
        _userManager = userManager;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
    {
        // Check Email
        var identityUser = await _userManager.FindByEmailAsync(request.Email);

        if (identityUser is not null)
        {
            // Check Password
            var checkPasswordResult = await _userManager.CheckPasswordAsync(identityUser, request.Password);

            if (checkPasswordResult)
            {
                //var roles = await _userManager.GetRolesAsync(identityUser);

                // Create a Token and Response
                var jwtToken = _tokenRepository.CreateJwtToken(identityUser);

                var response = new LogintResponseDTO()
                {
                    Email = request.Email,
                    Token = jwtToken
                };

                return Ok(response);
            }
        }
        ModelState.AddModelError("", "Email or Password Incorrect");


        return ValidationProblem(ModelState);
    }

    // POST: {apibaseurl}/api/auth/register
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
    {
        // Create IdentityUser object
        var user = new IdentityUser
        {
            UserName = request.Email?.Trim(),
            Email = request.Email?.Trim()
        };

        // Create User
        var identityResult = await _userManager.CreateAsync(user, request.Password);

        if (identityResult.Succeeded)
        {
            return Ok();
        }
        else
        {
            if (identityResult.Errors.Any())
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }

        return ValidationProblem(ModelState);
    }

}

