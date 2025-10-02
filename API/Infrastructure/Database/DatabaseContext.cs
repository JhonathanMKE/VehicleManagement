using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configurationAppSettings;
    public DatabaseContext(IConfiguration confiration)
    {
        _configurationAppSettings = confiration;
    }
    public DbSet<Administrator> Administrators { get; set; } = default!;
    //aqui é onde se faz o set do ORM que relaciona a tabela com a classe.
    //após a criação da classe e com o mapeamento executado, podemos executar
    //o migration do EntityFramework 
    // COMMAND: dotnet ef migrations add {migration_title}
    // COMMAND: dotnet ef databae update
    public DbSet<Vehicles> Vehicles { get; set; } = default!; 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>().HasData(
            new Administrator
            {
                Id = 1,
                Email = "administrator@teste.com",
                Password = "123456",
                Profile = "Admin"
            }
        );
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var stringConnection = _configurationAppSettings.GetConnectionString("mysql")?.ToString();
        if (!string.IsNullOrEmpty(stringConnection))
        {
            optionsBuilder.UseMySql(
                stringConnection,
                ServerVersion.AutoDetect(stringConnection)
            );
        }
        ;
    }
}