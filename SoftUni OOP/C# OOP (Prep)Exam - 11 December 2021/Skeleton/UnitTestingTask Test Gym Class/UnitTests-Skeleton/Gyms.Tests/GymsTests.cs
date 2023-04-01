using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        Gym gym;
        Athlete athlete;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym("Berkovica", 200);
            athlete = new Athlete("Gesha");
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

        [Test]
        public void Test_CapacityThrows_ArgumentException_WhenIsBellowZero()
        {
            int negativeCapacity = -2;

            Assert.Throws<ArgumentException>(() =>
            gym = new Gym("Berkovica", negativeCapacity), "Invalid gym capacity."
            );
        }

        [Test]
        public void Test_AddAthleteThrows_InvalidOperationException_WhenThereIsNoMoreCapacity()
        {
            gym = new Gym("Berkovica", 0); 

            Assert.Throws<InvalidOperationException>(() =>
            gym.AddAthlete(athlete), "The gym is full."
            );
        }
    }
}
