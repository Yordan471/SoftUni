using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RobotFactory.Tests
{


    public class Tests
    {
        Factory factory;
        Robot robot;
        Supplement supplement;

        [SetUp]
        public void Setup()
        {
            factory = new("Fac", 100);
            robot = new("4PO", 1000, 40);
            supplement = new("Supp", 40);
        }

        [Test]
        public void Test_FactoryConstructorSettingPropertiesCorrectly()
        {
            string expectedName = "Fac";
            int expectedCapacity = 100;

            Assert.That(expectedName, Is.EqualTo(factory.Name));
            Assert.That(expectedCapacity, Is.EqualTo(factory.Capacity));
            Assert.NotNull(factory.Supplements);
            Assert.NotNull(factory.Robots);
        }

        [Test]
        public void Test_ProduceRobotMethod_ReturnUnableToProduce_String()
        {
            string expectedString = "The factory is unable to produce more robots for this production day!";

            factory = new Factory("Fac", 0);

            string actualString = factory.ProduceRobot("4PO", 1000, 50);

            Assert.That(expectedString, Is.EqualTo(actualString));
        }

        [Test]
        public void Test_ProduceRobotMethod_WorksCorrectly()
        {
            string expectedOutput = $"Produced --> {robot}";

            string actualOutput = factory.ProduceRobot("4PO", 1000, 40);

            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
            Assert.That(1, Is.EqualTo(factory.Robots.Count));
        }

        [Test]
        public void Test_ProduceSupplementMethod_AddsGivenSupplementToCollection()
        {
            string expectedOutput = $"Supplement: Supp IS: 100";
            factory.ProduceSupplement("Supp", 100);
            string actualOutput = factory.Supplements.First().ToString();

            Assert.That(expectedOutput, Is.EqualTo(actualOutput));

            string actualOutputTwo = factory.ProduceSupplement("Supp", 100);
            Assert.That(expectedOutput, Is.EqualTo(actualOutputTwo));
            Assert.That(2, Is.EqualTo(factory.Supplements.Count));
        }

        [Test]
        public void Test_UpgradeRobotReturnsFalse()
        {
            Supplement firstSupp = new("SuppOne", 50);
            Supplement secondSupp = new("SuppSec", 60);
            robot = new("Spas", 100, 50);
            robot.Supplements.Add(firstSupp);
            factory.Robots.Add(robot);
           //robot.Supplements.Add(secondSupp);

            Assert.IsFalse(factory.UpgradeRobot(robot, firstSupp));

            
        }

        [Test]
        public void Test_UpgradeRobotReturnsFalse2()
        {
            factory.ProduceRobot("33", 40, 40);
            Robot firstR = factory.Robots.First();
            supplement = new("Supp", 100);

            Assert.IsFalse(factory.UpgradeRobot(firstR, supplement));
            Supplement twoSupplement = new("Supp", 40);
            Assert.IsTrue(factory.UpgradeRobot(firstR, twoSupplement));
            Supplement threeSupplement = new("Supp", 40);

        }

        [Test]
        public void Test_UpgradeRobotReturnsFalse3()
        {
            factory.ProduceRobot("4PO", 1000, 40);
            factory.ProduceSupplement("Supp", 40);
            Supplement secondSupp = new("SecondSupp", 60);
            //factory.ProduceSupplement("SecondSupp", 40);
            robot.Supplements.Add(supplement);

            Assert.IsFalse(factory.UpgradeRobot(robot, secondSupp));
        }

        [Test]
        public void Test_UpgradeRobotReturnsTrue()
        {
            factory.ProduceRobot("4PO", 1000, 40);
            factory.ProduceSupplement("Supp", 40);
            Supplement secondSupp = new("SecondSupp", 40);
            //factory.ProduceSupplement("SecondSupp", 40);
            robot.Supplements.Add(supplement);

            Assert.IsTrue(factory.UpgradeRobot(robot, secondSupp));
        }

        [Test]
        public void Test_SellRobotMethod_ReturnsSelectedRobots()
        {
            factory.ProduceRobot("3PO", 100, 50);
            Robot expectedRobot = new("3PO", 100, 50);
            factory.ProduceRobot("4PO", 150, 60);
            factory.ProduceRobot("5PO", 160, 60);

            Robot returnRobot = factory.SellRobot(120);
            string expectedString = $"Robot model: 3PO IS: 50, Price: 100.00";
            string actualString = returnRobot.ToString();
            Assert.That(expectedString, Is.EqualTo(actualString));
        }


        [Test]
        public void Test_SellRobotMethod_ReturnsSelectedRobots3()
        {
            factory.ProduceRobot("3PO", 100, 50);
            Robot expectedRobot = new("4PO", 150, 60);
            factory.ProduceRobot("4PO", 150, 60);
            factory.ProduceRobot("5PO", 160, 60);

            Robot returnRobot = factory.SellRobot(160);
            string expectedString = $"Robot model: 5PO IS: 60, Price: 160.00";
            string actualString = returnRobot.ToString();
            Assert.That(expectedString, Is.EqualTo(actualString));
        }
    }
}