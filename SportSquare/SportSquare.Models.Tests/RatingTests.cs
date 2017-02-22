using System;
using System.Linq;
using NUnit.Framework;
using SportSquare.Models.Contracts;

namespace SportSquare.Models.Tests
{
    [TestFixture]
    public class RatingTests
    {
        [Test]
        public void ConstructorWithParam_MustSetIsHiddenToFalse()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            var rate = 3;
            var rating = new Rating(userId, venueId, rate);

            // Assert
            Assert.AreEqual(false, rating.IsHidden);
        }

        [Test]
        public void ConstructorWithParams_MustCreateRating()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            var rate = 3;

            var rating = new Rating(userId, venueId, rate);

            // Assert
            Assert.IsInstanceOf<Rating>(rating);
        }

        [Test]
        public void ConstructorWithParams_MustNotSet_IdProperty()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            var rate = 3;

            var rating = new Rating(userId, venueId, rate);

            // Assert
            Assert.AreEqual(0, rating.Id);
        }

        [Test]
        public void ConstructorWithParams_MustSet_Rate()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            var rate = 3;

            var rating = new Rating(userId, venueId, rate);

            // Assert
            Assert.AreEqual(rate, rating.Rate);
        }

        [Test]
        public void ConstructorWithParams_MustSet_UserId()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            var rate = 3;

            var rating = new Rating(userId, venueId, rate);

            // Assert
            Assert.AreEqual(userId, rating.UserId);
        }

        [Test]
        public void ConstructorWithParams_MustSet_VenueId()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            var rate = 3;

            var rating = new Rating(userId, venueId, rate);

            // Assert
            Assert.AreEqual(venueId, rating.VenueId);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateRating()
        {
            // Arrange & Act
            var rating = new Rating();

            // Assert
            Assert.IsInstanceOf<Rating>(rating);
        }


        [Test]
        public void ParameterlessConstructor_MustSetIsHiddenToFalse()
        {
            // Arrange & Act
            var rating = new Rating();

            // Assert
            Assert.AreEqual(false, rating.IsHidden);
        }

        [Test]
        public void RatingPropertyId_MustBeSetCorectly()
        {
            // Arrange
            var rating = new Rating();
            var userGuid = Guid.NewGuid();

            // Act
            rating.UserId = userGuid;

            // Assert
            Assert.AreEqual(userGuid, rating.UserId);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void RatingPropertyIsHidden_MustBeSetCorectly(bool expected)
        {
            // Arrange
            var rating = new Rating();

            // Act
            rating.IsHidden = expected;

            // Assert
            Assert.AreEqual(expected, rating.IsHidden);
        }

        [Test]
        public void RatingPropertyRate_MustBeSetCorectly()
        {
            // Arrange
            var rating = new Rating();
            var rate = 3;

            // Act
            rating.Rate = rate;

            // Assert
            Assert.AreEqual(rate, rating.Rate);
        }


        [Test]
        public void RatingPropertyVenueId_MustBeSetCorectly()
        {
            // Arrange
            var rating = new Rating();
            var venueId = 3;

            // Act
            rating.VenueId = venueId;

            // Assert
            Assert.AreEqual(venueId, rating.VenueId);
        }

        [Test]
        public void IsRatingImplementHisInterfaces()
        {
            // Act & Arrange & Assert
            Assert.IsNotNull(typeof(Rating).GetInterfaces().SingleOrDefault(i => i == typeof(IDbModel)));
        }
    }
}