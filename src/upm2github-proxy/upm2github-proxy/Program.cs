using upm2github_proxy.Json;
using upm2github_proxy.Services;
using System.Text.Json;
using upm2github_proxy.Authentication;
using upm2github_proxy.Services.GitHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IAuthDictionary>(JsonSerializer.Deserialize<AuthDictionary>(File.ReadAllText("authdata.json")) ?? new AuthDictionary());

//builder.Services.AddSingleton<IRegistryService, MockRegistryService>();
builder.Services.AddSingleton<IRegistryService, GitHubRegistryService>();

builder.Services.AddControllers().AddJsonOptions(ApplicationJsonOptions.AddOptions);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
