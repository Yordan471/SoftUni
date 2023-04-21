using NUnit.Framework;
using System;
using System.Xml.Linq;

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

        [Test]
        public void Test_AddAthlete_AddsAthleteProperly()
        {
            gym = new Gym("Berkovica", 1);

            gym.AddAthlete(athlete);
            int expectedCount = 1;
            int actualCount = gym.Count;

            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [TestCase("Berkovica")]
        public void Test_RemoveAthleteThrows_InvalidOperationException_WhenAthleteIsNull(string name)
        {
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            gym.RemoveAthlete(name), $"The athlete {name} doesn't exist."
            );          
        }

        [TestCase("Gesha")]
        public void Test_RemoveAthlete_RemovesAthleteWithGivenName(string name)
        {
            gym.AddAthlete(athlete);
            int expectedCount = 0;

            gym.RemoveAthlete(name);
            int actualCount = gym.Count;

            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [TestCase("Berkovica")]
        public void Test_InjureAthleteThrows_InvalidOperationException_WhenAthleteIsNull(string name)
        {
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            gym.InjureAthlete(name), $"The athlete {name} doesn't exist."
            );
        }

        [TestCase("Gesha")]
        public void Test_InjureAthlete_ReturnsAthleteCorrectly(string name)
        {
            gym.AddAthlete(athlete);

            Athlete returnAthlete = gym.InjureAthlete(name);
            Athlete expectedAthlete = athlete;
            Assert.That(ReferenceEquals(expectedAthlete, returnAthlete));
        }

        [TestCase("Gesha")]
        public void Test_InjureAthlete_SetsIsInjuredToTrue(string name)
        {
            gym.AddAthlete(athlete);

            Athlete returnAthlete = gym.InjureAthlete(name);

            bool actualResult = returnAthlete.IsInjured;

            Assert.True(actualResult);
        }

        [Test]
        public void Test_ReportMethod_ReturnsStringOutputCorrectly()
        {
            Athlete athleteTwo = new Athlete("Pesho");
            Athlete athletethree = new Athlete("Spas");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athleteTwo);
            gym.AddAthlete(athletethree);

            athletethree.IsInjured = true;

            string expectedResult = $"Active athletes at {gym.Name}: {athlete.FullName}, {athleteTwo.FullName}";
            string actualResult = gym.Report();

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}
