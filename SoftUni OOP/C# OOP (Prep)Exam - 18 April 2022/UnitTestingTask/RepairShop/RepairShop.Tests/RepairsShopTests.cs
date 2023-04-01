using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            Garage garage;

            [SetUp]
            public void Setup()
            {
                garage = new Garage("Pesho", 4);
            }

            [Test]
            public void Test_GarageConstructor_SetsPropertiesCorrectly()
            {
                Assert.That("Pesho", Is.EqualTo(garage.Name));
                Assert.That(4, Is.EqualTo(garage.MechanicsAvailable));
            }

        }
    }
}