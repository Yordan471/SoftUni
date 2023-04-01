using NUnit.Framework;

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
    }
}
