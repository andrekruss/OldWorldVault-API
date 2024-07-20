namespace OldWorldVault.Api.Models;

public class User 
{
    public int Id { get; }
    public string Username { get; }
    public string Email { get; }
    public string Password { get; }
    public bool IsActive { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public User(
        string username,
        string email,
        string password,
        bool isActive,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Username = username;
        Email = email;
        Password = password;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}