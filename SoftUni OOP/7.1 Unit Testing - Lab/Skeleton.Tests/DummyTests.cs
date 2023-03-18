using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        Dummy dummy;
        int dummyHealth;
        int dummyExp;

        [SetUp]
        public void SetUp()
        {
            dummyHealth = 100;
            dummyExp = 10;
            dummy = new(dummyHealth, dummyExp);
        }

        [Test]
        public void TestDummyConstructor()
        {
            Assert.That(dummy.Health, Is.EqualTo(dummyHealth), "Dummy Health points are different then the one set from the constructor");
        }

        [Test]
        public void Test_DummyIsDead_WithHealthPoints_EqualZero()
        {
            dummyHealth = 0;
            dummy = new(dummyHealth, dummyExp);

            Assert.That(dummyHealth, Is.EqualTo(0), "Dummy health points are 0, so it should be dead.");
        }

        [Test]
        public void Test_DummyIsDead_WithHealthPointsBellowZero()
        {
            dummyHealth = -5;
            dummy = new(dummyHealth, dummyExp);

            Assert.Negative(dummyHealth, "Dummy health points are negative number, so it should be dead.");
        }
    }
}