using DataLayer;
<<<<<<< HEAD
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
=======
using Microsoft.EntityFrameworkCore;
using Npgsql;
>>>>>>> 30086cc3d512026bcb61640ad649b8a69dd763cd

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IDataService, DataService>();

<<<<<<< HEAD
builder.Services.AddSingleton<Hashing>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Auth:secret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero

        };
    });
=======
//builder.Services.AddSingleton<IUserService, UserService>();
>>>>>>> 30086cc3d512026bcb61640ad649b8a69dd763cd

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

<<<<<<< HEAD
app.Run();
=======
app.Run();


>>>>>>> 30086cc3d512026bcb61640ad649b8a69dd763cd
