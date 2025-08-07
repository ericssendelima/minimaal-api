using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<DbContexto>();
db.Database.Migrate();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
  if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
  {
    return Results.Ok("Login com sucesso");
  }
  else
  {
    return Results.Unauthorized();
  }
});


app.Run();

