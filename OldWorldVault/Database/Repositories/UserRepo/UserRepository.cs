using OldWorldVault.Dtos.UserDtos;
using OldWorldVault.Database.Entities;

namespace OldWorldVault.Database.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly OldWorldVaultDbContext _context;
        public UserRepository(OldWorldVaultDbContext context)
        {
            _context = context;
        }

        public async Task Insert(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Username = createUserDto.Username,
                Password = createUserDto.Password,
                IsActive = createUserDto.IsActive,
                CreatedAt = createUserDto.CreatedAt,
                UpdatedAt = createUserDto.UpdatedAt,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
