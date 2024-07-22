namespace OldWorldVault.Dtos.UserDtos;

public record CreateUserDto(
    string Username,
    string Email,
    string Password,
    bool IsActive,
    DateTime CreatedAt,
    DateTime UpdatedAt
);