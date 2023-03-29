using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        Hotel hotel;

        [SetUp]
        public void Setup()
        {
            string fullName = "Holyday";
            int category = 5;

            hotel = new Hotel(fullName, category);
        }

        [Test]
        public void Test_IfConstructor_SetsProperties_Correctly()
        {
            string fullName = "Spaskovec";
            int category = 4;

            hotel = new Hotel(fullName, category);

            string expectedFullName = fullName;
            int expectedCategory = category;

            Assert.That(expectedFullName, Is.EqualTo(expectedFullName));
            Assert.That(expectedCategory, Is.EqualTo(expectedCategory));
            Assert.True(hotel.Rooms != null);
            Assert.True(hotel.Bookings != null);
        }  
    }
}