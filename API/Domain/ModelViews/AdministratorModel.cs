using Domain.Enums;

namespace vehicle_management.Domain.ModelViews;

public record AdministratorModel
{
    public int Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public Profile? Profile { get; set; } = default!; //se quiser mostrar o perfil pro usuario pode deixar como string
}