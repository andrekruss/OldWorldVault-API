using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OldWorldVault.Database;
using OldWorldVault.Database.Repositories.UserRepo;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<OldWorldVaultDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("OldWorldVaultDb")));
    builder.Services.AddTransient<IUserRepository, UserRepository>();
}   

var app = builder.Build();
{
    app.MapControllers();
    app.Run();
}