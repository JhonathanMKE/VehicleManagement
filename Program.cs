using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using vehicle_management.Domain.ModelViews;
using Domain.Services;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#region Builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IadministratorService, AdministratorService>();  //?? O esse escopo faz.
builder.Services.AddScoped<IVehicleService, VehiclesService>();
var conn = builder.Configuration.GetConnectionString("mysql") ?? throw new InvalidOperationException("Connection String not found.");

builder.Services.AddDbContext<DatabaseContext>(options =>
{
options.UseMySql(
    conn,
    ServerVersion.AutoDetect(conn)
    );
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Home
app.MapGet("/", () => Results.Json(new Home())).WithTags("Home");
#endregion

#region Login
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
.WithOpenApi()
.WithTags("Login");
#endregion

#region Veiculos
app.MapPost("/vehicles", ([FromBody] VehicleDTO vehicleDTO, IVehicleService vehicleService) =>
{
    var v = new Vehicles
    {
        Name = vehicleDTO.Name,
        Vendor = vehicleDTO.Vendor,
        FabricationYear = vehicleDTO.FabricationYear
    };

    vehicleService.Include(v);

    return Results.Created($"/vehicle/{v.Id}", v);

}
)
.WithTags("Vehicles");

app.MapGet("/vehicles", ([FromQuery] int? page, IVehicleService vehicleService) =>
{
    var vehicles = vehicleService.ListAll(page);
    return Results.Ok(vehicles);
})
.WithTags("Vehicles");

app.MapGet("/vehicles/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.FindById(id);
    if (vehicle == null) return Results.NotFound();
    return Results.Ok(vehicle);
})
.WithTags("Vehicles");

app.MapPut("/vehicles/{id}", ([FromRoute] int id, VehicleDTO vehicleDTO, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.FindById(id);
    if (vehicle == null) return Results.NotFound();
    vehicle.Name = vehicleDTO.Name;
    vehicle.Vendor = vehicleDTO.Vendor;
    vehicle.FabricationYear = vehicleDTO.FabricationYear;
    vehicleService.Update(vehicle);

    return Results.Ok(vehicle);
})
.WithTags("Vehicles");

app.MapDelete("/vehicles/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.FindById(id);
    if (vehicle == null) return Results.NotFound();
    vehicleService.Delete(vehicle);

    return Results.NoContent();
})
.WithTags("Vehicles");
#endregion



app.Run();

