using Domain.Entities; //importing namespace from API

namespace Test.Domain;

[TestClass]
public class VehiclesTest
{
    [TestMethod]
    public void TestGetsSetsProps()
    {
        //Arrange
        var v = new Vehicles();

        //Act
        v.Name = "Fiesta";
        v.Id = 1;
        v.Vendor = "Ford";
        v.FabricationYear = 2005;

        //Assert
        Assert.AreEqual(1, v.Id);
        Assert.AreEqual("Fiesta", v.Name);
        Assert.AreEqual("Ford", v.Vendor);
        Assert.AreEqual(2005, v.FabricationYear);

        //via terminal run dotnet test
    }
}