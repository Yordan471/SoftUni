using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        Gym gym;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym("Berkovica", 200);
        }

        [Test]
        public void Test_GymConstructor_SettingPropertiesCorrectly()
        {
            string expectedGymName = "Berkovica";
            int expectedGymSize = 200;
            
            Assert.That(expectedGymName, Is.EqualTo(gym.Name));
            Assert.That(expectedGymSize, Is.EqualTo(gym.Capacity));
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_NamePropertie_ThrowsArgumentNullException_WhenValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            gym = new Gym(name, 200) , "Invalid gym name."
            );
        }
    }
}
