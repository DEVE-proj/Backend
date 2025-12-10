using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    options.UseNpgsql(connectionString);

});

builder.Services.AddScoped<IUserRepo, UserRepo>();

var app = builder.Build();

app.MapControllers();

app.Run();