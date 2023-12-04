using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Extensions;
using CalorieTracker.Server.Repository;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddSqlite<ApplicationDbContext>(connectionString);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;

    if (builder.Environment.IsDevelopment())
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 4;
        options.Password.RequiredUniqueChars = 0;
    };

}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

builder.Services.AddTransient<IFoodDiaryEntryService, FoodDiaryEntryService>();
builder.Services.AddTransient<IDiaryService, DiaryService>();
builder.Services.AddTransient<IAccountService, AccountService>();

builder.Services.AddScoped<IMealTypeRepository, MealTypeRepository>();
builder.Services.AddScoped<IDiaryRepository, DiaryRepository>();
builder.Services.AddScoped<IFoodDiaryRepository, FoodDiaryRepository>();
builder.Services.AddScoped<IFoodDiaryEntryRepository, FoodDiaryEntryRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseHttpsRedirection();

app.RegisterAccountEndpoints();
app.RegisterDiaryEndpoints();
app.RegisterFoodDiaryEntryEndpoints();

app.MapFallbackToFile("/index.html");

app.Run();
