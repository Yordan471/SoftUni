namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

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

        [Test]
        public void Test_AddMethodThrows_InvalidOperationException_WhenCapacityIsReached()
        {
            robotManager = new RobotManager(1);
            Robot newRobot = new Robot("Peshaka", 20);
            robotManager.Add(newRobot);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Add(robot), "Not enough capacity!");
        }

        [Test]
        public void Test_RemoveMethodThrows_InvalidOperationException_WhenRobotIsMissing()
        {
            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Remove(robot.Name), $"Robot with the name {robot.Name} doesn't exist!"
            );
        }

        [Test]
        public void Test_RemoveMethod_RemovesRobotCorrectly()
        {
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);

            Assert.That(0, Is.EqualTo(robotManager.Count));           
        }

        [Test]
        public void Test_WorkMethodThrows_InvalidOperationException_WhenThereIsNoSuchRobot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Work(robot.Name, "Drive", 20), $"Robot with the name {robot.Name} doesn't exist!"
            );
        }

        [Test]
        public void Test_WorkMethodThrows_InvalidOperationException_WhenBatteryUsage_IsBiggerThen_BatteryCapacity()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Work(robot.Name, "Drive", 200), $"{robot.Name} doesn't have enough battery!"
            );
        }

        [Test]
        public void Test_WorkMethod_WorksCorrectly()
        {
            robotManager.Add(robot);

            robotManager.Work(robot.Name, "Drive", 50);

            int expectedBattery = 100;

            Assert.That(expectedBattery, Is.EqualTo(robot.Battery));
        }
    }
}
