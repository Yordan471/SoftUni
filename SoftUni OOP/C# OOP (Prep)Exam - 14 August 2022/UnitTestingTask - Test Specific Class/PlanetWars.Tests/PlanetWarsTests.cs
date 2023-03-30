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
            }
        }

        [TestFixture]

        public class WeaponTests
        {

        }
    }
}
