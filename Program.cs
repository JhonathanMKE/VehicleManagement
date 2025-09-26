using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IadministratorService, AdministratorService>();  //?? O esse escopo faz.

var conn = builder.Configuration.GetConnectionString("mysql") ?? throw new InvalidOperationException("Connection String not found.");

builder.Services.AddDbContext<DatabaseContext>(options =>
{
options.UseMySql(
    conn,
    ServerVersion.AutoDetect(conn)
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IadministratorService administratorServices) =>
{
    if (administratorServices.Login(loginDTO)!= null) //chamando o método Login do AdministratorService.cs com o contrator de uma interface iAdministratorService.cs
    //como ele permite o retorno nulo. Caso seja diferente de nulo é pq existe e foi retornado o objeto administrador.
    {
        return Results.Ok("Login com sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
}
)
.WithName("Login")
.WithOpenApi();


app.Run();

