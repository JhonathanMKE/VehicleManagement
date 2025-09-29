using Domain.Entities;
using Domain.DTOs;

namespace Domain.Interfaces;

public interface IadministratorService
{
    Administrator? Login(LoginDTO loginDTO); //a interrogação nessa interface indica que pode retornar nulo.
    Administrator Include(Administrator administrator);

    List<Administrator> ListAll(int? page);

    Administrator? FindById(int Id);

}