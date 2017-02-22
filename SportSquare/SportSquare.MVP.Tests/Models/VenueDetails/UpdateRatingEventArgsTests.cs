using NUnit.Framework;
using SportSquare.MVP.Models.VenueDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.MVP.Tests.Models.VenueDetails
{
    [TestFixture]
    public class UpdateRatingEventArgsTests
    {
        const string userId = "45";
        const string venueId = "55";
        const string rating = "3";

        [Test]
        public void AddCommentEventArgsTestsCorectly_NewInstanceIsCreated()
        {
            var actualInstance = new UpdateRatingEventArgs(userId, venueId, rating);
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void AddCommentEventArgsTestsCorectly_NewInstanceIsCreatedOfSameType()
        {
            var actualInstance = new UpdateRatingEventArgs(userId, venueId, rating);
            Assert.IsInstanceOf(typeof(UpdateRatingEventArgs), actualInstance);
        }


        [Test]
        public void COnstructorSetsUserIDCorrectly()
        {
            var actualInstance = new UpdateRatingEventArgs(userId, venueId, rating);
            Assert.AreEqual(userId, actualInstance.UserID);
        }
        [Test]
        public void COnstructorSetsVenueIdCorrectly()
        {
            var actualInstance = new UpdateRatingEventArgs(userId, venueId, rating);
            Assert.AreEqual(venueId, actualInstance.VenueId);
        }
        [Test]
        public void COnstructorSetsCommentCorrectly()
        {
            var actualInstance = new UpdateRatingEventArgs(userId, venueId, rating);
            Assert.AreEqual(rating, actualInstance.RatingNew);
        }
    }
}
