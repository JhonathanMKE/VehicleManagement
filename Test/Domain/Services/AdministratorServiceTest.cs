using Domain.Services; //importing namespace from API
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Security.Cryptography;


namespace Test.Domain;

[TestClass]
public class AdministratorServiceTest
{

    private DatabaseContext CreateDbContext() //usando a classe de Infrastructure.Database
    {
        var AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(AssemblyPath ?? "","..","..","..")); //voltando 3 itens ".." - Utilizado para apontar para Test/appsettings.json (databaseTest)
        var builder = new ConfigurationBuilder()
        .SetBasePath(path ?? Directory.GetCurrentDirectory()) //resolvenod warning caso venha nulo
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

        var configuration = builder.Build();

        // var connectionString = configuration.GetConnectionString("MySql");

        // var options = new DbContextOptionsBuilder<DbContext>()
        // .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        // .Options;

        return new DatabaseContext(configuration);
    }

    [TestMethod]
    public void AdministratorPersistence()
    {
        //Arrange
        var context = CreateDbContext();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administrators"); //limpa a tabela antes de executar o teste.

        var adm = new Administrator();
        adm.Email = "teste@teste.com";
        adm.Password = "teste";
        adm.Profile = "adm";
        
        var administratorService = new AdministratorService(context);

        //Act
        administratorService.Include(adm);


        //Assert
        Assert.AreEqual(1, administratorService.ListAll(1).Count()); //verifica se existe um elemento inserido no banco.

        //via terminal run dotnet test
    }
}