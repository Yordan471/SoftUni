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
			song = new Song("Geraka", new TimeSpan(0, 1, 10));
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
		public void Test_AddSongToPerformer_AddsGivenSongToGivenPerformer()
		{
			stage.AddSong(song);
			stage.AddPerformer(performer);

			string actualString = stage.AddSongToPerformer(song.Name, performer.FullName);
			string expectedString = $"{song} will be performed by {performer.FullName}";

			Assert.That(expectedString, Is.EqualTo(actualString));
        }

		[Test]
		public void Test_Play_ReturnsStringCorrectly()
		{
            stage.AddSong(song);
            stage.AddPerformer(performer);
			stage.AddSongToPerformer(song.Name, performer.FullName);

			string expectedString = $"{stage.Performers.Count} performers played 1 songs";
            string actualString = stage.Play();

			Assert.That(actualString, Is.EqualTo(expectedString));
        }

		[Test]
		public void Test_GetPerformer_ThrowsArgumentException_WhenPerformerDoesntExist()
		{
			//performer = null;
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() =>
			stage.AddSongToPerformer(song.Name, performer.FullName), "There is no performer with this name."
			);
        }

        [Test]
        public void Test_GetSong_ThrowsArgumentException_WhenSongDoesntExist()
        {
            //performer = null;
            stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(() =>
            stage.AddSongToPerformer(song.Name, performer.FullName), "There is no song with this name."
            );
        }

		[Test]
		public void Test_ValidateNullValue_ArgumentNullException_WhenVariableIsNullForSong()
		{
			song = null;

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(song) );
		}

		[Test]
		public void Test_ValidateNullValue_ArgumentNullException_WhenVariableIsNullForPerformer()
		{
			stage.AddSong(song);
			performer = null;

			Assert.Throws<ArgumentNullException>(() =>
			stage.AddPerformer(performer));
		}
    }
}