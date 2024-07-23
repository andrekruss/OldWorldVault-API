using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OldWorldVault.Database;
using OldWorldVault.Database.Repositories.UserRepo;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<OldWorldVaultDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("OldWorldVaultDb")));
    builder.Services.AddTransient<IUserRepository, UserRepository>();

    var configuration = new ConfigurationBuilder()
        .AddUserSecrets<Program>()
        .Build();

    var jwtKey = configuration["JWT_SECRET_KEY"];
    if (string.IsNullOrEmpty(jwtKey))
    {
        throw new InvalidOperationException("JWT_SECRET_KEY is not set in the user secrets");
    }

    var key = Encoding.ASCII.GetBytes(jwtKey);
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    // Add Authorization
    builder.Services.AddAuthorization();
}   

var app = builder.Build();
{
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}