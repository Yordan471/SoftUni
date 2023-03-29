using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private string footballTeamName = "Spaskovci";
        private int footballTeamCapacity = 15;

        FootballTeam footballTeam;

        [SetUp]
        public void Setup()
        {
            footballTeam = new FootballTeam(footballTeamName, footballTeamCapacity);
        }

        [Test]
        public void TestIf_ConstructorSetsProperties_Correctly()
        {
            string FBName = "Peshovci";
            int FBCapacity = 18;

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
            footballTeam.Name = null , "Name cannot be null or empty!"
            );

            Assert.Throws<ArgumentException>(() =>
            footballTeam.Name = string.Empty, "Name cannot be null or empty!"
            );
        }
    }
}