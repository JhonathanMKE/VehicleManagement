using Domain.Entities; //importing namespace from API

namespace Test.Domain;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestGetsSetsProps()
    {
        //Arrange
        var adm = new Administrator();

        //Act
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Password = "teste";
        adm.Profile = "adm";

        //Assert
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste", adm.Password);
        Assert.AreEqual("adm", adm.Profile);

        //via terminal run dotnet test
    }
}