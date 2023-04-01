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
            Car car;

            [SetUp]
            public void Setup()
            {
                garage = new Garage("Pesho", 4);
                car = new Car("Ford", 4);
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

            [Test]
            public void Test_CarsInGarage_GetsCarsCount()
            {
                garage.AddCar(car);

                Assert.That(garage.CarsInGarage, Is.EqualTo(1));
            }

            [Test]
            public void Test_AddCarThrows_InvalidOperationException_WhenCarsCount_Equals_AvailableMechanics()
            {
                garage = new Garage("Peuget", 1);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() => 
                garage.AddCar(car), "No mechanic available."
                );
            }

            [Test]
            public void Test_AddCar_WorksCorrectly()
            {
                garage = new Garage("Peuget", 1);
                garage.AddCar(car);

                Assert.That(1, Is.EqualTo(garage.CarsInGarage));
            }

            [TestCase("Peuget")]
            public void Test_FixCarThrows_InvalidOperationException_WhenThereIsNoCar_WithCarModel(string carModel)
            {
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                garage.FixCar(carModel), $"The car {carModel} doesn't exist."
                );
            }
        }
    }
}