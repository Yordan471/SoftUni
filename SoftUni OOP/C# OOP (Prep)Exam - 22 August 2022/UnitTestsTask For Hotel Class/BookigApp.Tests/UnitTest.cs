using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Cryptography;

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

        [Test]

        public void Test_TurnoverIsZero()
        {
            double expectedTurnover = 0;
            double actualTurnover = hotel.Turnover;

            Assert.That(expectedTurnover, Is.EqualTo(actualTurnover));
        }

        [Test]

        public void Test_IfFullNameProperty_ThrowsArgumentNullException()
        {
            //hotel = new Hotel(null, 4);

            Assert.Throws<ArgumentNullException>(() =>
            hotel = new Hotel(null, 4), "FullName Can't be null or empty"
            );

            Assert.Throws<ArgumentNullException>(() =>
            hotel = new Hotel(string.Empty, 4), "FullName Can't be null or empty"
            );
        }

        [TestCase(0)]
        [TestCase(6)]

        public void Test_IfCategory_Throws_ArgumentException_WhenIsUnderOne_Or_AboveFive(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            hotel = new Hotel("Peshovec", category), "Category can't be bellow 1 and above 5"
            );
        }

        [Test]

        public void Test_AddRoomMethod_IfAddsRoom()
        {
            Room room = new Room(3, 20);

            hotel.AddRoom(room);

            Room expectedRoom = room;
            Room ActualRoom = hotel.Rooms.First();

            Assert.AreEqual(expectedRoom, ActualRoom);
        }

        [TestCase(0, 2, 3, 4)]
        [TestCase(-1, 2, 3, 4)]

        public void Test_BookRoomMethod_IfAdultsLessOrEqualToZero_ThrowsArgumentException(int adults, int children, int residenceDuration, double budget)
        {
            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, residenceDuration, budget), "Adults can't be less or Equal to 0"
            );
        }

        [TestCase(2, -1, 3, 4)]

        public void Test_BookRoomMethod_IfChildrenAreLessThenZero_ThrowsArgumentException(int adults, int children, int residenceDuration, double budget)
        {
            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, residenceDuration, budget), "Adults can't be less or Equal to 0"
            );
        }

        [TestCase(2, 1, 0, 2)]
        [TestCase(2, 1, -1, 2)]
        public void Test_BookRoomMethod_IfResidenceDurationIsLessThenOne_ThrowsArgumentException(int adults, int children, int residenceDuration, double budget)
        {
            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, residenceDuration, budget), "Adults can't be less or Equal to 0"
            );
        }

        [TestCase(2, 2, 2, 100)]

        public void Test_IfBookRoomMethod_NotEnoughBeds(int adults, int children, int residenceDuration, double budget)
        {
            Room room = new Room(3, 50);
            hotel.AddRoom(room);

            hotel.BookRoom(adults, children, residenceDuration, budget);
            double expectedturnover = 0;

            Assert.AreEqual(expectedturnover, hotel.Turnover);
        }

        [TestCase(2, 2, 2, 10)]
        
        public void Test_IfBookRoomMethod_NotEnoughBudget(int adults, int children, int residenceDuration, double budget)
        {
            Room room = new Room(3, 50);
            hotel.AddRoom(room);

            hotel.BookRoom(adults, children, residenceDuration, budget);
            double expectedturnover = 0;

            Assert.AreEqual(expectedturnover, hotel.Turnover);
        }

        [TestCase(2, 2, 2, 40)]
        public void Test_IfBookRoomMethod_WorksCorrectly(int adults, int children, int residenceDuration, double budget)
        {
            Room room = new Room(4, 20);
            hotel.AddRoom(room);

            hotel.BookRoom(adults, children, residenceDuration, budget);
            double expectedturnover = 40;

            Assert.AreEqual(expectedturnover, hotel.Turnover);
        }
    }
}