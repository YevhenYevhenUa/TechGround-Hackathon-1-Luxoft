using Hackathon_Task.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly numobotdbContext _context;

    public UsersController(numobotdbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Return all users from database
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users.ToListAsync();

        if (users.Count == 0)
        {
            return NotFound("Users was not found");
        }

        return Ok(users);
    }

    /// <summary>
    /// returns users who have children of a certain age.
    /// </summary>
    /// <param name="age">The age of the child of the users we need</param>
    /// <returns></returns>
    [HttpGet]
    [Route("ChildrenAge")]
    public async Task<IActionResult> ChildrenAge([FromQuery] int age)
    {
        var users = await _context.Users.Where(u => u.Children.Any(u => u.Age == age)).ToListAsync();
        if(users.Count == 0)
        {
            return NotFound($"no users with children of this age: {age} were found");
        }

        return Ok(users);
    }

    [HttpGet]
    [Route("TelegramUsers")]
    public async Task<IActionResult> TelegramUsers([FromQuery]string utmSource)
    {
        var users = await _context.Users.Where(u => u.UtmSource == utmSource).ToListAsync();

        if (users.Count == 0)
        {
            return NotFound($"Users from: {utmSource} is not found");
        }

        return Ok(users);
    }

}
