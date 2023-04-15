namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    public class AquariumsTests
    {
        Aquarium aquarium;
        Fish fish;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("Spasoka", 2);
            fish = new Fish("Geshaka");
        }

        [Test]
        public void Test_AquariumConstructor_SetsPropertiesCorrectly()
        {
            string expectedName = "Spasoka";
            int expectedCapacity = 2;

            Assert.That(expectedName, Is.EqualTo(aquarium.Name));
            Assert.That(expectedCapacity, Is.EqualTo(aquarium.Capacity));
        }

        [Test]
        public void Test_CountReturnsFishCount()
        {
            int expectedCount = 0;

            Assert.That(expectedCount, Is.EqualTo(aquarium.Count));
        }

        [Test]
        public void Test_AddMethod_ThrowsInvalidOperationException_WhenCapacityIsReached()
        {
            aquarium = new Aquarium("spasoka", 1);
            aquarium.Add(fish);
            Fish secondFish = new Fish("Goshko");

            Assert.Throws<InvalidOperationException>(() =>
            aquarium.Add(secondFish), "Aquarium is full!"
            );
        }

        [Test]
        public void Test_AddMethod_AddsFishToCollection()
        {
            aquarium.Add(fish);
            int expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(aquarium.Count));
        }

        [Test]
        public void Test_RemoveFish_ThrowsInvalidOperationException_WhenFishIsNull()
        {
            aquarium.Add(fish);
            Fish secondFish = new Fish("Goshko");

            Assert.Throws<InvalidOperationException>(() =>
            aquarium.RemoveFish(secondFish.Name), $"Fish with the name {secondFish.Name} doesn't exist!"
            );
        }

        [Test]
        public void Test_RemoveFish_RemovesGivenFishByName()
        {
            aquarium.Add(fish);

            aquarium.RemoveFish(fish.Name);

            Assert.That(0, Is.EqualTo(aquarium.Count));
        }

        [Test]
        public void Test_SellFish_ThrowsInvalidOperationException_WhenRequestedFishIsntFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            aquarium.SellFish(fish.Name), $"Fish with the name {fish.Name} doesn't exist!"
            );
        }

        [Test]
        public void Test_SellFish_SoldFishStatusSetsToFals()
        {
            aquarium.Add(fish);

            aquarium.SellFish(fish.Name);

            Assert.False(fish.Available);
        }

        [Test]
        public void Test_SellFish_SellsRequestedFish()
        {
            aquarium.Add(fish);

            Fish secondFish = aquarium.SellFish(fish.Name);

            Assert.AreEqual(fish, secondFish);
        }

        [Test]
        public void Test_Report_ReturnsString()
        {
            aquarium.Add(fish);
            Fish secondFish = new Fish("Goshko");
            aquarium.Add(secondFish);

            string expectedString = $"Fish available at {aquarium.Name}: Geshaka, Goshko";
            string actualString = aquarium.Report();

            Assert.That(expectedString, Is.EqualTo(actualString));
        }

        [Test]
        public void Test_FishConstructor_SetsPropertiesCorectly()
        {
            string expectedName = "Geshaka";
            bool expectedAvailability = true;

            Assert.That(expectedName, Is.EqualTo(expectedName));
            Assert.That(expectedAvailability, Is.True);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_AquariumName_ThrowsArgumentNullException_IsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            aquarium = new Aquarium(name, 2), "Invalid aquarium name!"
            );           
        }

        [Test]
        public void Test_Capacity_Throws_ArgumentException_WhenValueIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            aquarium = new Aquarium("spasoka", -1), "Invalid aquarium capacity!"
            );
            
        }
    }
}
