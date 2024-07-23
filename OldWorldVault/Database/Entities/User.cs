using System.ComponentModel.DataAnnotations;

namespace OldWorldVault.Database.Entities;

public class User 
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Username { get; set; }

    [Required]
    [MaxLength(200)]
    public string Password { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }
}