using System.Text;
using System.Text.Json.Serialization;
using _Project_CheatSheet;
using _Project_CheatSheet.Common.CurrentUser;
using _Project_CheatSheet.Common.CurrentUser.Interfaces;
using _Project_CheatSheet.Features.Category.Interfaces;
using _Project_CheatSheet.Features.Category.Services;
using _Project_CheatSheet.Features.Comment.Interfaces;
using _Project_CheatSheet.Features.Comment.Services;
using _Project_CheatSheet.Features.Course.Interfaces;
using _Project_CheatSheet.Features.Course.Services;
using _Project_CheatSheet.Features.Identity.Interfaces;
using _Project_CheatSheet.Features.Identity.Services;
using _Project_CheatSheet.Features.Likes.Interfaces;
using _Project_CheatSheet.Features.Likes.Services;
using _Project_CheatSheet.Features.Profile.Interfaces;
using _Project_CheatSheet.Features.Profile.Services;
using _Project_CheatSheet.Features.Resources.Interfaces;
using _Project_CheatSheet.Features.Resources.Services;
using _Project_CheatSheet.Features.Statistics.Interfaces;
using _Project_CheatSheet.Features.Statistics.Services;
using _Project_CheatSheet.Features.Topics.Interfaces;
using _Project_CheatSheet.Features.Topics.Services;
using _Project_CheatSheet.Features.Videos.Interfaces;
using _Project_CheatSheet.Features.Videos.Services;
using _Project_CheatSheet.Infrastructure.Data;
using _Project_CheatSheet.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();
builder.Services.AddTransient<IResourceService, ResourceService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ILikeService, LikeService>();
builder.Services.AddTransient<IStatisticsService, StatisticService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<ITopicService, TopicService>();
builder.Services.AddTransient<IVideoService, VideoService>();

builder.Services.AddScoped<ICurrentUser, CurrentUser>();

builder.Services.AddDbContext<CheatSheetDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>()
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
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontEnd = configuration.GetValue<string>("FrontEnd");

    options.AddDefaultPolicy(corsBuilder => { corsBuilder.WithOrigins(frontEnd).AllowAnyMethod().AllowAnyHeader(); });
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
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddMvc(c => c.Conventions.Add(new ApiExplorerIgnore()));
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Cheat sheet swagger API", Version = "v1" });
});

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Cheat sheet swagger API"); });
}

app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(e => { e.MapControllers(); });

app.Run();