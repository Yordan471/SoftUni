// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using Microsoft.VisualBasic;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
		Stage stage;
		Performer performer;
		Song song;

		[SetUp]
		public void SetUp()
		{
			stage = new Stage();
			performer = new Performer("Geshaka", "Ivanov", 19);
			song = new Song("Geraka", new TimeSpan(0, 0, 10));
		}

		[Test]
	    public void Test_StageConstructorInitializes_Collections()
		{
			Assert.NotNull(stage.Performers);
		}

		[Test]
		public void Test_AddPerformer_IfAgeIsBellow18()
		{
			performer = new Performer("Geshaka", "Ivanov", 17);

			Assert.Throws<ArgumentException>(() =>
			stage.AddPerformer(performer), "You can only add performers that are at least 18."
			);			
		}

		[Test]
		public void Test_AddPerformer_AddsPerformerToCollection()
		{
			stage.AddPerformer(performer);
			
			Assert.That(1, Is.EqualTo(stage.Performers.Count));
		}

		[Test]
		public void Test_AddSong_ThrowsArgumentException_WhenSongDurationsIsLessThenOne()
		{
			song = new Song("Geraka", new TimeSpan(0, 0, 0));

			Assert.Throws<ArgumentException>(() =>
			stage.AddSong(song), "You can only add songs that are longer than 1 minute."
			);			
		}

		[Test]
		public void Test_AddSong_AddsGivenSong()
		{
			stage.AddSong(song);
		}
    }
}