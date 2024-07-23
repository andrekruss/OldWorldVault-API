using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OldWorldVault.Contracts.User;
using OldWorldVault.Database.Repositories.UserRepo;
using OldWorldVault.Dtos.UserDtos;

namespace OldWorldVault.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase 
{
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser(CreateUserRequest request) 
    {

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new CreateUserDto(
            request.Username,
            request.Email,
            hashedPassword,
            true,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        // TODO: Save user to database
        await _userRepository.Insert(user);

        return Ok(user);
    }

}