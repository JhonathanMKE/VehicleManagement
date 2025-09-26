using Domain.Entities;
using Domain.DTOs;

namespace Domain.Interfaces;

public interface IVehicleService
{
    List<Vehicles>? ListAll(int page = 1, string? nome = null, string? marca = null); //a interrogação nessa interface indica que pode retornar nulo.
    Vehicles FindById(int Id);
    void Include(Vehicles V);
    void Update(Vehicles V);
    void Delete(Vehicles V);
}