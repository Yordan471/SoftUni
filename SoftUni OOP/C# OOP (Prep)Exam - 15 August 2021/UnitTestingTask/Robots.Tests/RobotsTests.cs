namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(10);
        }

        [Test]
        public void Test_Constructor_SettingPropertiesCorrectly()
        {
            int expectedCapacity = 10;

            Assert.That(expectedCapacity, Is.EqualTo(robotManager.Capacity));
        }

        [Test]
        public void Test_CapacityThrows_ArgumentException_WhenValueIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            robotManager = new RobotManager(-1), "Invalid capacity!"
            );
        }
    }
}
