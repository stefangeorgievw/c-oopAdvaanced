// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
 
    using NUnit.Framework;
    using System;
    using System.Globalization;
    using System.Text;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void TestConstructor()
	    {
            var stage = new Stage();
            var set = new Short("Ivan");
            
            stage.AddSet(set);
            var setController = new SetController(stage);
            var result = setController.PerformSets();
            var sb = new StringBuilder();
            sb.AppendLine("1. Ivan:");
            sb.AppendLine("-- Did not perform");
            Assert.That(result, Is.EqualTo(sb.ToString().Trim()));

		}

        [Test]
        public void TestSuccessful()
        {
            var stage = new Stage();
           
            var set = new Short("Ivan");
            stage.AddSet(set);
            var duraction = DateTime.ParseExact("01:20", "mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
            var performer = new Performer("Stefan", 20);
            performer.AddInstrument(new Guitar());
            stage.AddPerformer(performer);
            var song = new Song("Song1", duraction);
            stage.AddSong(song);
            set.AddSong(song);
            set.AddPerformer(performer);
            var setController = new SetController(stage);
            var result = setController.PerformSets();
            var sb = new StringBuilder();
            sb.AppendLine($"1. Ivan:");
            sb.AppendLine($"-- 1. Song1 ({duraction:mm\\:ss})");
            sb.AppendLine("-- Set Successful");
            Assert.That(result, Is.EqualTo(sb.ToString().Trim()));







            

        }
    }
}