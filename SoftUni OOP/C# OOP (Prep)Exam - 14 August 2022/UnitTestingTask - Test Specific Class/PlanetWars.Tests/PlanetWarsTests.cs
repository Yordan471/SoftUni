using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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

            [Test]

            public void Test_UpgradeWeapon_WorksCorrectly()
            {
                planet.AddWeapon(weapon);
                int weaponDestructionLevelIncreased = weapon.DestructionLevel + 1;

                planet.UpgradeWeapon(weapon.Name);
                int actualWeaponDestuctionLevel = weapon.DestructionLevel;

                Assert.That(weaponDestructionLevelIncreased, Is.EqualTo(actualWeaponDestuctionLevel));
            }

            [Test]
            
            public void Test_DestructOpponent_ThrowsInvalidOperationException()
            {
                Planet opponentPlanet = new Planet("Gesha", 100);
                Weapon opponentWeapon = new Weapon("Gesha's Weapon", 100, 201);
                opponentPlanet.AddWeapon(opponentWeapon);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                planet.DestructOpponent(opponentPlanet), $"{opponentPlanet.Name} is too strong to declare war to!"
                );
            }

            [Test]

            public void Test_DestructOpponent_WorksCorrectly_OpponendIsDestroyed()
            {
                Planet opponent = new Planet("Gesha", 100);
                string expectedResult = $"{opponent.Name} is destructed!";

                Weapon opponentWeapon = new Weapon("Gesha's Weapon", 100, 90);
                opponent.AddWeapon(opponentWeapon);

                planet.AddWeapon(weapon);

                string actualResult = planet.DestructOpponent(opponent);

                Assert.That(expectedResult, Is.EqualTo(actualResult));
            }

            [TestFixture]

            public class WeaponTests
            {
                private Weapon weapon;

                [SetUp]
                public void Setup()
                {
                    weapon = new Weapon("Peshkata", 100, 150);
                }


                [Test]
                public void Test_WeaponConstructor_SettingPropertiesCorrectly()
                {
                    Weapon weapon = new Weapon("MK-16", 120, 200);

                    string expectedWeaponName = "MK-16";
                    double expectedWeaponPrice = 120;
                    int expecteWeaponDestructionLevel = 200;

                    Assert.That(expectedWeaponName, Is.EqualTo(expectedWeaponName));
                    Assert.That(expectedWeaponPrice, Is.EqualTo(expectedWeaponPrice));
                    Assert.That(expecteWeaponDestructionLevel, Is.EqualTo(expecteWeaponDestructionLevel));
                }

                [Test]
                public void Test_PricePropertie_ThrowsArgumentException_WhenNegative()
                {
                    double weaponPrice = -10;

                    Assert.Throws<ArgumentException>(() =>
                    weapon = new Weapon("AK", weaponPrice, 200), "Price cannot be negative."
                    );
                }

                [Test]
                public void Test_IncreaseDestructionLevel_IncreaseByOne_WhenCalled()
                {
                    int expectedWeaponDestructionLevel = 151;
                    
                    weapon.IncreaseDestructionLevel();

                    int actualWeaponDestructionLevel = weapon.DestructionLevel;

                    Assert.That(expectedWeaponDestructionLevel, Is.EqualTo(actualWeaponDestructionLevel));
                }

                [Test]
                public void Test_IsNuclear_SetsToTrue_When_DestructionLevel_BiggerOrEualToTen()
                {
                    weapon.DestructionLevel = 10;
                    Assert.True(weapon.IsNuclear);

                    weapon.DestructionLevel = 9;
                    Assert.False(weapon.IsNuclear);
                }
            }
        }
    }
}
