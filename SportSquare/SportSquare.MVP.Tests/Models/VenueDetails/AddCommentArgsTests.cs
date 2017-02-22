using NUnit.Framework;
using SportSquare.MVP.Models.VenueDetails;

namespace SportSquare.MVP.Tests.Models.VenueDetails
{
    [TestFixture]
    public class AddCommentArgsTests
    {

        const string userId = "45";
        const string venueId = "55";
        const string comment = "alabala portokala";

        [Test]
        public void AddCommentEventArgsTestsCorectly_NewInstanceIsCreated()
        {
            var actualInstance = new AddCommentEventArgs(userId, venueId, comment);
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void AddCommentEventArgsTestsCorectly_NewInstanceIsCreatedOfSameType()
        {
            var actualInstance = new AddCommentEventArgs(userId, venueId, comment);
            Assert.IsInstanceOf(typeof(AddCommentEventArgs), actualInstance);
        }


        [Test]
        public void COnstructorSetsUserIDCorrectly()
        {
            var actualInstance = new AddCommentEventArgs(userId, venueId, comment);
            Assert.AreEqual(userId, actualInstance.UserID);
        }
        [Test]
        public void COnstructorSetsVenueIdCorrectly()
        {
            var actualInstance = new AddCommentEventArgs(userId, venueId, comment);
            Assert.AreEqual(venueId, actualInstance.VenueId);
        }
        [Test]
        public void COnstructorSetsCommentCorrectly()
        {
            var actualInstance = new AddCommentEventArgs(userId, venueId, comment);
            Assert.AreEqual(comment, actualInstance.Comment);
        }
    }
}
