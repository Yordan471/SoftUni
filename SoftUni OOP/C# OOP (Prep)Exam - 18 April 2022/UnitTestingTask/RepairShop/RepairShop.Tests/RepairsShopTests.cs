using NUnit.Framework;
using System;
using System.Xml.Linq;

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

            [TestCase(0)]
            [TestCase(-1)]
            public void Test_MechanicsAvailableThrows_ArgumentException_WhenValueIs_BelowOrEqualToZero(int numberOfMechanics)
            {
                Assert.Throws<ArgumentException>(() =>
                garage = new Garage("Peshaka", numberOfMechanics), "At least one mechanic must work in the garage."
                );
            }
        }
    }
}