using Microsoft.EntityFrameworkCore;
using OldWorldVault.Database.Entities;

namespace OldWorldVault.Database;

public class OldWorldVaultDbContext : DbContext
{
    public OldWorldVaultDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set;}
}