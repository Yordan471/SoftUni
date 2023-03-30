using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            Planet planet;

            [SetUp]
            
            public void SetUp()
            {
                planet = new Planet("Mercury", 505.40);
            }

            [Test]

            public void Test_PlanetWarsConstructor_SetsPropertiesCorrectly()
            {
                Assert.That("Mercury", Is.EqualTo(planet.Name));
                Assert.That(505.40, Is.EqualTo(planet.Budget));
                Assert.True(planet.Weapons != null);
            }

            [Test]

            public void Test_NamePropery_ThrowArgumentException()
            {
                Assert.Throws<ArgumentException>(() =>
                planet = new Planet(string.Empty, 20), "Invalid planet Name"
                );

                Assert.Throws<ArgumentException>(() => 
                planet = new Planet(null, 20), "Invalid planet Name"
                );
            }

            [Test]

            public void Test_BudgetValue_LessThenZero()
            {
                Assert.Throws<ArgumentException>(() =>
                planet = new Planet("Zdravko", -1), "Budget cannot drop below Zero!"
                );
            }

            [Test]

            public void Test_MillitaryWeaponsRatio_GetsWeaponsSum()
            {
                double actualMilPowRat = planet.MilitaryPowerRatio;

                Assert.That(0, Is.EqualTo(actualMilPowRat));
            }

            [TestCase(20)]

            public void Test_ProfitMethod_AddsAmountToBudget(double amount)
            {
                planet = new Planet("Crash", 0);
                planet.Profit(amount);
                double expectedBudget = 20;

                Assert.That(expectedBudget, Is.EqualTo(planet.Budget));
            }

            [TestCase(20)]

            public void Test_SpendFundsThrows_InvalidOperationException(double amount)
            {
                planet = new Planet("Crash", 0);
                Assert.Throws<InvalidOperationException>(() =>
                planet.SpendFunds(amount), $"Not enough funds to finalize the deal."
                );
            }

            [TestCase(20)]

            public void Test_SpendFundsThrows_WorksCorrectly(double amount)
            {
                planet = new Planet("Crash", 40);
                planet.SpendFunds(amount);
                double expectedBudget = 40 - 20;

                Assert.That(expectedBudget, Is.EqualTo(planet.Budget));
            }
        }

        [TestFixture]

        public class WeaponTests
        {

        }
    }
}
