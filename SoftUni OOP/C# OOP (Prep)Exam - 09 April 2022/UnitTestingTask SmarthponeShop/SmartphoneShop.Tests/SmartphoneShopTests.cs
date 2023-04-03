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
    }
}