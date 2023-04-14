namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Globalization;

    [TestFixture]
    public class PresentsTests
    {
        Present present;
        Bag bag = new Bag();

        [SetUp]
        public void SetUp()
        {
            present = new Present("Spas", 2.5);
        }

        [Test]
        public void Test_ConstructorSetPropertiesCorrectly()
        {
            string expectedName = "Spas";
            string actualName = present.Name;

            double expectedMagick = 2.5;
            double actualMagick = present.Magic;

            Assert.That(expectedName, Is.EqualTo(actualName));
            Assert.That(expectedMagick, Is.EqualTo(actualMagick));
        }

        [Test]
        public void Test_BagConstructorInitializes_PrivateFieldPresents()
        {
            Assert.NotNull(bag.GetPresents());
        }

        [Test]
        public void Test_CreateMethodThrows_ArgumentNullException_WhenPresentIsNull()
        {
            Present nullPresent = null;

            Assert.Throws<ArgumentNullException>(() =>
            bag.Create(nullPresent), "Present is null");
        }

        [Test]
        public void Test_CreateMethodThrows_InvalidOperationException_WhenPresentAlreadyExists()
        {
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            bag.Create(present), "This present already exists!");
        }

        [Test]
        public void Test_CreateMethod_AddsPresentToCollection()
        {
            bag.Create(present);
            Present newPresent = new Present("Geraka", 3.4);
            bag.Create(newPresent);
            Present ExpectedPresent = newPresent;

            Assert.Contains(ExpectedPresent, bag.GetPresents() as ICollection);
        }

        [Test]
        public void Test_CreateMethod_ReturnsStringWhenSuccessfulyAdded()
        {           
            string actualString = bag.Create(present);
            string expectedString = $"Successfully added present {present.Name}.";

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void Test_RemoveMethod_RemovesGivenPresent()
        {
            bag.Create(present);

            bag.Remove(present);

            Assert.IsEmpty(bag.GetPresents());
        }

        [Test]
        public void Test_GetPresentWithLeastMagicMethod_WorksCorrectly()
        {
            bag.Create(present);
            Present newPresent = new Present("Geraka", 3.4);
            bag.Create(newPresent);

            Present actualPresent = bag.GetPresentWithLeastMagic();

            Assert.Equals(present, actualPresent);
        }
    }
}
