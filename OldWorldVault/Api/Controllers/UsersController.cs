using Microsoft.AspNetCore.Mvc;
using OldWorldVault.Contracts.User;
using OldWorldVault.Api.Models;

namespace OldWorldVault.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase 
{

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request) 
    {
        var user = new User(
            request.Username,
            request.Email,
            request.Password,
            true,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        // TODO: Save user to database
        return Ok(user);
    }

}