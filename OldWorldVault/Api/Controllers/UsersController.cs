namespace OldWorldVault.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase 
{

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request) 
    {
        
    }

}