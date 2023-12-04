using CalorieTracker.Server.Data;
using CalorieTracker.Server.Endpoints;
using CalorieTracker.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddSqlite<ApplicationDbContext>(connectionString);

builder.Services.ConfigureIdentity(builder.Environment);
builder.Services.RegisterServices();

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

app.MapDiaryEndpoints();
app.MapAccountEndpoints();

app.MapFallbackToFile("/index.html");

app.Run();
