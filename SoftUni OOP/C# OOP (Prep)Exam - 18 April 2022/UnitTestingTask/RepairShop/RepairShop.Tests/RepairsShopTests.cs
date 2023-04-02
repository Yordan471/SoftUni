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

            [TestCase("Ford")]
            public void Test_FixCar_SetsNumberOfIssuesToZero(string carModel)
            {
                garage.AddCar(car);

                garage.FixCar(carModel);
                int expectedIssues = 0;
                Car fixedCar = car;

                Assert.That(expectedIssues, Is.EqualTo(car.NumberOfIssues));
                Assert.That(car, Is.EqualTo(fixedCar));
            }

            [Test]
            public void Test_RemoveFixedCarsThrows_InvalidOperationException_When_ThereAreNoBrokenCars()
            {
                garage.AddCar(car);
                //garage.FixCar("Ford");

                Assert.Throws<InvalidOperationException>(() => 
                garage.RemoveFixedCar(), $"No fixed cars available."
                );
            }

            [Test]
            public void Test_RemoveFixedCars_RemovesCarsIsFixedCars()
            {
                garage.AddCar(car);
                Car secondCar = new Car("Peuget", 4);
                garage.FixCar("Ford");
                garage.AddCar(secondCar);
                garage.FixCar("Peuget");

                garage.RemoveFixedCar();

                int expectedCount = 0;
                int actualCount = garage.CarsInGarage;

                Assert.That(expectedCount, Is.EqualTo(actualCount));
            }

            [Test]
            public void Test_Report_TestIfReturnsCorrectString()
            {
                garage.AddCar(car);
                Car secondCar = new Car("Peuget", 4);
                //garage.FixCar("Ford");
                garage.AddCar(secondCar);
                //garage.FixCar("Peuget");

                string expectedResult = $"There are {garage.CarsInGarage} which are not fixed: {car.CarModel}, {secondCar.CarModel}.";
                string actualResult = garage.Report();

                Assert.That(expectedResult, Is.EqualTo(actualResult));
            }
        }
    }
}