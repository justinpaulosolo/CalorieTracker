using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Features.Account.Commands;
using CalorieTracker.Server.Features.Account.Queries;
using CalorieTracker.Server.Features.MealEntries.Commands;
using CalorieTracker.Server.Features.MealEntries.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;

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

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsProduction())
{
    var keyVaultUrl = builder.Configuration.GetSection("KeyVault:KeyVaultURL");
    var keyVaultClient = new KeyVaultClient(
        new KeyVaultClient.AuthenticationCallback(new AzureServiceTokenProvider().KeyVaultTokenCallback));
    builder.Configuration.AddAzureKeyVault(keyVaultUrl.Value!.ToString(), new DefaultKeyVaultSecretManager());

    var client = new SecretClient(new Uri(keyVaultUrl.Value!.ToString()), new DefaultAzureCredential());

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(client.GetSecret("ProductionDbConnectionString").Value.Value.ToString());
    });
}

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
}

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

app.MapFallbackToFile("/index.html");

app.Run();