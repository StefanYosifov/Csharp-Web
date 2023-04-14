using _Project_CheatSheet.Data;
using _Project_CheatSheet.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<CheatSheetDbContent>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<CheatSheetDbContent>();


builder.Services.AddControllers();


var provider = builder.Services.BuildServiceProvider();
var configuration=provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontEnd = configuration.GetValue<string>("FrontEnd");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontEnd).AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}

app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(e=>
{
    e.MapControllers();
});

app.Run();
