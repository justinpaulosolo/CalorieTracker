using CalorieTracker.Server.Data;
using CalorieTracker.Server.Users;
using CalorieTracker.Server.Account;
using CalorieTracker.Server.Features.MealEntries.Create;
using CalorieTracker.Server.Features.MealEntries.GetByDate;
using CalorieTracker.Server.Features.MealEntries.GetByDateMeal;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlServer<ApplicationDbContext>(connectionString);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapAccount();
app.CreateMealEntryEndpoint();
app.GetMealEntriesByDate();
app.GetMealEntriesByDateMeal();

app.MapFallbackToFile("/index.html");

app.Run();
