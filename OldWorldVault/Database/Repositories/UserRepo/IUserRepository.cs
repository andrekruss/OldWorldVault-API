using OldWorldVault.Dtos.UserDtos;

namespace OldWorldVault.Database.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task Insert(CreateUserDto createUserDto);
    }
}
