namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using DataPapi.Helpers;
using DataPapi.Models.Authentication;
using DataPapi.Services;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect. Please try again with correct credentials." });

        return Ok(response);
    }

    // using custom Authorize attribute
    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}