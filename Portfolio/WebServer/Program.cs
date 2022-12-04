using DataLayer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IDataService, DataService>();

//builder.Services.AddSingleton<Hashing>();

/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
    });*/
<<<<<<< HEAD
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();
//app.UseAuthentication();
//app.UseAuthorization();
=======
//builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();
/*app.UseAuthentication();
app.UseAuthorization();*/
>>>>>>> 5c7b6429dc55cfa71d964856096b1a5cdefe076b

app.MapControllers();

app.Run();
app.Run();



