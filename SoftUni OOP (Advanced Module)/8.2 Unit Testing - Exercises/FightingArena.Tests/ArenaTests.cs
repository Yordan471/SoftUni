namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior firstWarrior;
        private Warrior secondWarrior;
        [SetUp]
        public void Setup()
        {
            firstWarrior = new Warrior("viking", 50, 80);
            secondWarrior = new Warrior("secondViking", 60, 90);
            arena = new Arena();
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
        }

        [Test]
        public void ValidateIfArenaIncreaseCountAfterEnrollCommand()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(() => arena.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_WarriorsNotNull_AfterInstantiation()
        {
            Assert.NotNull(arena.Warriors);
        }

        [Test]
        public void ValidateIfArenaContainsEnrolledWarrior()
        {
            // Arrange
            // Act

            // Assert
            Warrior warriorTest = new Warrior("Peshaka", 60, 100);
            arena.Enroll(warriorTest);
            Assert.That(3, Is.EqualTo(arena.Warriors.Count));
            Assert.That(() => arena.Warriors, Has.Member(firstWarrior));

        }

        [Test]
        public void ValidateIfEnrollCommandThrowExceptionWhenWarriorIsAlreadyEnrolled()
        {
            // Arrange
            // Act

            // Assert
            Assert.That(() => arena.Enroll(firstWarrior), Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void ValidateIfFightCommandThrowExceptionWhenDefenderWarriorIsMissing()
        {
            // Arrange
            // Act
            var defender = new Warrior("anotherOrk", 50, 60);

            // Assert
            Assert.That(() => arena.Fight(firstWarrior.Name, defender.Name), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {defender.Name} enrolled for the fights!"));
        }

        [Test]
        public void ValidateIfFightCommandThrowExceptionWhenAttackerWarriorIsMissing()
        {
            // Arrange
            // Act
            var attacker = new Warrior("ork", 60, 80);

            // Assert
            Assert.That(() => arena.Fight(attacker.Name, firstWarrior.Name), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {attacker.Name} enrolled for the fights!"));
        }

        [Test]
        public void ValidateIfAttackCommandWorkCorrectlyWhenBothOfWarriorsExistInTheArena()
        {
            // Arrange
            // Act
            arena.Fight(firstWarrior.Name, secondWarrior.Name);

            int expectedFirstWarHp = 20;
            int expectedSecondWarHp = 40;
            // Assert
            Assert.That(expectedFirstWarHp, Is.EqualTo(firstWarrior.HP));
            Assert.That(expectedSecondWarHp, Is.EqualTo(secondWarrior.HP));
            //Assert.That(() => firstWarrior.Attack(secondWarrior), !Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {secondWarrior.Name} enrolled for the fights!"));
        }

        [Test]
        public void Test_FightMethod_WhenBothWarriorsAreNull_ReturnDefenderNameAsMissing()
        {
            var defender = new Warrior("anotherOrk", 50, 60);
            var attacker = new Warrior("ork", 60, 80);
            

            Assert.Throws<InvalidOperationException>(() =>
            arena.Fight(attacker.Name, defender.Name), $"There is no fighter with name {defender.Name} enrolled for the fights!"
            );
        }
    }
}
