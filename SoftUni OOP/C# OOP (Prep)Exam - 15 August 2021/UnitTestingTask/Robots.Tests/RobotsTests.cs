namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        RobotManager robotManager;
        Robot robot = new Robot("Geshaka", 150);

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

        [Test]
        public void Test_Count_GetsRobotsCount()
        {
            Assert.That(0, Is.EqualTo(robotManager.Count));
        }

        [Test]
        public void Test_AddMethodThrows_InvalidOperationException_WhenThereIsARobot_WithSaidName()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Add(robot), $"There is already a robot with name {robot.Name}!"
            );
        }
    }
}
