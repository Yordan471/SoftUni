using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        Shop shop;
        Smartphone phone;

        [SetUp]
        public void SetUp()
        {
            shop = new(10);
            phone = new("Nokia", 100);
        }

        [Test]
        public void Test_ConstructorSettingProperties_Correctly()
        {
            int expectedCapacity = 10;
            int actualCapacity = shop.Capacity;

            Assert.That(expectedCapacity, Is.EqualTo(actualCapacity));
        }

        [Test]
        public void Test_CapacityThrows_ArgumentException_WhenValueIsBellowZero()
        {
            int setCapacity = -1;

            Assert.Throws<ArgumentException>(() =>
            shop = new(setCapacity), "Invalid capacity."
            );
        }

        [Test]
        public void Test_CountReturns_PhonesCount()
        {
            int expectedCount = 0;
            int actualCount = shop.Count;

            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public void Test_AddMethodThrows_InvalidOperationException_WhenThePhoneAlreadyExists()
        {
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            shop.Add(phone), $"The phone model {phone.ModelName} already exist."
            );
        }

        [Test]
        public void Test_AddMethodThrows_InvalidOperationException_WhenCapacityEqualsCount_And_WeTryToAddPhone()
        {
            shop = new(1);

            shop.Add(phone);
            Smartphone newPhone = new("Sony", 50);

            Assert.Throws<InvalidOperationException>(() =>
            shop.Add(newPhone), "The shop is full."
            );
        }

        [Test]
        public void Test_AddMethod_AddsPhone()
        {
            shop.Add(phone);

            Assert.That(1, Is.EqualTo(shop.Count));
        }

        [Test]
        public  void Test_RemoveMethodThrows_InvalidOperationException_WhenSuchPhoneDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            shop.Remove(phone.ModelName), $"The phone model {phone.ModelName} doesn't exist."
            );
        }

        [Test]
        public void Test_RemoveMethod_RemovesGivenPhone()
        {
            shop.Add(phone);
            Assert.That(1, Is.EqualTo(shop.Count));

            shop.Remove(phone.ModelName);
            Assert.That(0, Is.EqualTo(shop.Count));
        }

        [Test]
        public void Test_TestPhoneThrows_InvalidOperationException_WhenThereIsNoSuchPhone()
        {
            Assert.Throws<InvalidOperationException>(() =>
            shop.TestPhone(phone.ModelName, 40), $"The phone model {phone.ModelName} doesn't exist."
            );
        }
    }
}