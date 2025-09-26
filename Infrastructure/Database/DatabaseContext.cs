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