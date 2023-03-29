using NUnit.Framework;
using System;
using System.Linq;
using System.Numerics;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private string footballTeamName = "Spaskovci";
        private int footballTeamCapacity = 15;

        FootballTeam footballTeam;
        FootballPlayer player;

        [SetUp]
        public void Setup()
        {
            footballTeam = new FootballTeam(footballTeamName, footballTeamCapacity);
            player = new FootballPlayer("Pesho", 18, "Midfielder");
        }

        [Test]
        public void TestIf_ConstructorSetsProperties_Correctly()
        {
            string FBName = "Peshovci";
            int FBCapacity = 15;

            footballTeam = new FootballTeam(FBName, FBCapacity);

            Assert.That(FBName, Is.EqualTo(footballTeam.Name));
            Assert.That(FBCapacity, Is.EqualTo(footballTeam.Capacity));
            Assert.That(footballTeam.Players != null, Is.True);
        }

        [Test]
        public void Test_NameThrowsArgumentException_WhenNullOrEmpty()
        {
            footballTeam.Name = " ";
            Assert.Throws<ArgumentException>(() =>
            footballTeam.Name = null, "Name cannot be null or empty!"
            );

            Assert.Throws<ArgumentException>(() =>
            footballTeam.Name = string.Empty, "Name cannot be null or empty!"
            );
        }

        [Test]

        public void Test_CapacityThrows_ArgumentException_WhenValueIsUnder15()
        {
            Assert.Throws<ArgumentException>(() =>
             footballTeam.Capacity = 14, "Capacity min value = 15"
             );
        }

        [Test]

        public void Test_AddNewPlayer_AddsNewPlayer_Method()
        {
            footballTeam.Players.Add(player);
            int playersCount = footballTeam.Players.Count;
            Assert.That(playersCount, Is.EqualTo(footballTeam.Players.Count));
        }

        [Test]

        public void Test_AddNewPlayer_ReturnsString_WhenCapacityIsFull()
        {

            string result = string.Empty;
            string expectedOutput = "No more positions available!";

            for (int i = 0; i < 20; i++)
            {
                result = footballTeam.AddNewPlayer(player);
            }

            footballTeam.AddNewPlayer(player);


            Assert.That(expectedOutput, Is.EqualTo(result));
        }

        [Test]
        public void Test_AddNewPlayer_ReturnsString_AfterAddingPlayer()
        {
            string expectedOutput = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            string actualOutput = string.Empty;

            actualOutput = footballTeam.AddNewPlayer(player);

            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [TestCase("Pesho")]

        public void Test_PickPlayer_ReturnsPlayerByName(string name)
        {
            footballTeam.AddNewPlayer(player);
            FootballPlayer expectedPlayer = player;

            FootballPlayer actualPickedPlayer = footballTeam.Players
                .FirstOrDefault(p => p.Name == name);

            Assert.AreEqual(expectedPlayer, actualPickedPlayer);
        }
    }
}