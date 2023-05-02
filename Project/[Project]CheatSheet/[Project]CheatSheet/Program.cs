using _Project_CheatSheet.Common.CurrentUser;
using _Project_CheatSheet.Common.CurrentUser.Interfaces;
using _Project_CheatSheet.Controllers.Category.Interfaces;
using _Project_CheatSheet.Controllers.Category.Services;
using _Project_CheatSheet.Controllers.Profile.Interfaces;
using _Project_CheatSheet.Controllers.Resources.Interfaces;
using _Project_CheatSheet.Controllers.Resources.Service;
using _Project_CheatSheet.Data;
using _Project_CheatSheet.Data.Models;
using _Project_CheatSheet.Features.Comment.Interfaces;
using _Project_CheatSheet.Features.Comment.Services;
using _Project_CheatSheet.Features.Identity.Interfaces;
using _Project_CheatSheet.Features.Identity.Services;
using _Project_CheatSheet.Features.Likes.Interfaces;
using _Project_CheatSheet.Features.Likes.Services;
using _Project_CheatSheet.Features.Profile.Services;
using _Project_CheatSheet.Features.Statistics.Interfaces;
using _Project_CheatSheet.Features.Statistics.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();
builder.Services.AddTransient<IResourceService,ResourceService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ILikeService, LikeService>();
builder.Services.AddTransient<IStatisticsService, StatisticService>();
builder.Services.AddTransient<IProfileService, ProfileService>();

builder.Services.AddTransient<ICurrentUser, CurrentUser>();


builder.Services.AddDbContext<CheatSheetDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<CheatSheetDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 2;
});


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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
 {
     options.SaveToken = true;
     options.RequireHttpsMetadata = false;
     options.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidAudience = configuration["JWT:ValidAudience"],
         ValidIssuer = configuration["JWT:ValidIssuer"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
     };
 });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
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