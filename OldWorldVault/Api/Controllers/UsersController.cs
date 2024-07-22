using Microsoft.AspNetCore.Mvc;
using OldWorldVault.Contracts.User;
using OldWorldVault.Database.Repositories.UserRepo;
using OldWorldVault.Dtos.UserDtos;

namespace OldWorldVault.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase 
{
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request) 
    {
        var user = new CreateUserDto(
            request.Username,
            request.Email,
            request.Password,
            true,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        // TODO: Save user to database
        await _userRepository.Insert(user);

        return Ok(user);
    }

}