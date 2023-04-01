using NUnit.Framework;
using System;

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

            [TestCase("")]
            [TestCase(null)]
            public void Test_NameThrows_ArgumentNullException_WhenValueIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                garage = new Garage(name, 4), "Invalid garage name."
                );
            }
        }
    }
}