using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OldWorldVault.Database;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<OldWorldVaultDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("OldWorldVaultDb")));
}   

var app = builder.Build();
{
    app.MapControllers();
    app.Run();
}