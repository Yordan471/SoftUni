using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        Dummy dummy;
        Dummy dummyWithZeroHealth;
        Dummy dummyWithNegativeHealth;

        int dummyPositiveHealth;
        int dummyExp;
        int dummyZeroHealth;
        int dummyNegativeHealth;

        [SetUp]
        public void SetUp()
        {
            dummyPositiveHealth = 100;
            dummyZeroHealth = 0;
            dummyNegativeHealth = -5;
            dummyExp = 10;

            dummy = new(dummyPositiveHealth, dummyExp);
            dummyWithZeroHealth = new(dummyZeroHealth, dummyExp);
            dummyWithNegativeHealth = new(dummyNegativeHealth, dummyExp);
        }

        [Test]
        public void TestDummyConstructor()
        {
            Assert.That(dummy.Health, Is.EqualTo(dummyPositiveHealth), "Dummy Health points are different then the one set from the constructor");
        }

        [Test]
        public void Test_DummyIsDead_WithHealthPoints_EqualZero()
        {
            Assert.That(dummyZeroHealth, Is.EqualTo(0), "Dummy health points are 0, so it should be dead.");
        }

        [Test]
        public void Test_DummyIsDead_WithHealthPointsBellowZero()
        {
            Assert.Negative(dummyNegativeHealth, "Dummy health points are negative number, so it should be dead.");
        }

        [Test]
        public void Test_WhenDummyIsDead_GiveExp()
        {
            Assert.That(dummyWithNegativeHealth.Health, Is.AtMost(0), "Dummy is dead so it should give expirience.");
        }

        [Test]
        public void Test_WhenDummyIsNotDead_DoNotGiveExp_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            dummy.GiveExperience(), "Dummy isn't Dead, you should not give exp");
        }

        [Test]
        public void Test_DummyTakesAttackAndLoosesHealth()
        {
            int damageTaken = 2;
            int dummyHealthLeft = dummy.Health - damageTaken;
            dummy.TakeAttack(damageTaken);

            Assert.That(dummy.Health, Is.EqualTo(dummyHealthLeft), "Dummy health is not the right amount after taking an attack");
        }
    }
}