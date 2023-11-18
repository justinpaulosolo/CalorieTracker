using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Features.Account.Commands;
using CalorieTracker.Server.Features.Account.Queries;
using CalorieTracker.Server.Features.Meals.Commands;
using CalorieTracker.Server.Features.Meals.Queries;
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
        options.User.RequireUniqueEmail = false;
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

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssemblies(typeof(Program).Assembly));

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

app.CreateAccountEndpoint();
app.LoginEndpoint();
app.LogoutEndpoint();
app.AccountInfoEndpoint();

app.CreateMealEntryEndpoint();
app.DeleteMealEntryEndpoint();
app.GetMealEntriesByDateAndTypeEndpoint();
app.GetMealsTotalMacrosByDateEndpoint();

app.EditMealEntryEndpoint();
app.MapGetMealEntryByIdEndpoint();

app.MapFallbackToFile("/index.html");

app.Run();