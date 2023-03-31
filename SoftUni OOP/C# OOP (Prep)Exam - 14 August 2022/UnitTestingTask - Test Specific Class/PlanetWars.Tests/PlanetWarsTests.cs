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
            Weapon weapon;

            [SetUp]

            public void SetUp()
            {
                planet = new Planet("Mercury", 505.40);
                weapon = new Weapon("Spas", 5000, 200);
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

            [Test]

            public void Test_AddWeapon_Throws_InvalidOperationException_WhenWeaponIsNotFound()
            {
                Weapon weapon = new Weapon("Peshkovec", 20, 20);

                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() =>
                planet.AddWeapon(weapon), $"There is already a {weapon.Name} weapon."
                );
            }

            [Test]

            public void Test_AddWeapon_WorksCorrectly()
            {
                Weapon weapon = new Weapon("Peshkovec", 20, 20);
                planet.AddWeapon(weapon);

                Assert.That(1, Is.EqualTo(planet.Weapons.Count));
            }

            [Test]

            public void Test_RemoveWeaponMethod_RemovesWeaponFromCollection()
            {
                planet.AddWeapon(weapon);

                Assert.That(1, Is.EqualTo(planet.Weapons.Count));

                planet.RemoveWeapon(weapon.Name);

                Assert.That(0, Is.EqualTo(planet.Weapons.Count));
            }

            [Test]

            public void Test_UpgradeWeapon_ThrowsInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(() =>
                planet.UpgradeWeapon(weapon.Name), $"{weapon.Name} does not exist in the weapon repository of {planet.Name}"
                );
                
            }

            [TestFixture]

            public class WeaponTests
            {

            }
        }
    }
}
