using DataLayer;


/*var ds = new DataService();

var attributes = ds.GetAkaAttributes();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();*/


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IDataService, DataService>();

builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.MapControllers();

app.Run();
