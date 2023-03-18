using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Security.AccessControl;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        Axe axe;
        Dummy dummy;
        int axeAttack;
        int axeDurability;
        int dummyHealth;
        int dummyExp;

        [SetUp]
        public void SetUp()
        {
            axeAttack = 10;
            axeDurability = 10;
            axe = new Axe(axeAttack, axeDurability);

            dummyHealth = 100;
            dummyExp = 10;
            dummy = new Dummy(dummyHealth, dummyExp);
        }


        [Test]

        public void AxeGettersTest()
        {
            //const int attackPoints = 10;
            //const int durabilityPoints = 10;

            axe = new(axeAttack, axeDurability);

            Assert.That(axe.AttackPoints, Is.EqualTo(axeAttack), "Axe attack points is getting incorrect number");
            Assert.That(axe.DurabilityPoints, Is.EqualTo(axeDurability), "Axe durability points is getting incorrect number");
        }

        [Test]
        public void AxeLoosingDurabilityAfterAttacking()
        { 
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability isn't showing correct loss numbers after attacking");
        }

        [Test]
        public void Attacking_WithAxeDurability_EquallsZero()
        {
            axeDurability = 0;

            axe = new(axeAttack, axeDurability);

            Assert.Throws<InvalidOperationException>(() =>
            axe.Attack(dummy), "Axe durability points are 0, you can't attack"
            );
        }

        [Test]
        public void Attacking_WithAxeDurability_BellowZeroPoints()
        {
            axeDurability = -5;

            axe = new(axeAttack, axeDurability);

            Assert.Throws<InvalidOperationException>(() =>
            axe.Attack(dummy), "Axe durability points are bellow 0, you can't attack"
            );
        }
    }
}