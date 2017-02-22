using System;
using System.Linq;

using NUnit.Framework;

using SportSquare.Models.Contracts;
using System.Collections.Generic;

namespace SportSquare.Models.Tests
{
    [TestFixture]
    public class UserWishVenueTests
    {
        [Test]
        public void ConstructorWithParams_MustCreateUserWishVenue()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var wish = new UserWishVenue(userId);

            // Assert
            Assert.IsInstanceOf<UserWishVenue>(wish);
        }

        [Test]
        public void ConstructorWithParams_MustSetUserId_OnInit()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var wish = new UserWishVenue(userId);

            // Assert
            Assert.AreEqual(userId, wish.UserId);
        }

        [Test]
        public void ConstructorWithParams_MustCreateVenueCollection_OnInit()
        {
            // Arrange & Act
            var userId = Guid.Empty;
            var wish = new UserWishVenue(userId);

            // Assert
            Assert.IsNotNull(wish.UserId);
        }


        [Test]
        public void ConstructorWithParams_MustSetIsHiddenToFalse_OnInit()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var wish = new UserWishVenue(userId);

            // Assert
            Assert.IsFalse(wish.IsHidden);
        }

        [Test]
        public void ConstructorWithParams_MustNotSetUser_OnInit()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var wish = new UserWishVenue(userId);

            // Assert
            Assert.IsNull(wish.User);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateUserWishVenue()
        {
            // Arrange & Act
            var type = new UserWishVenue();

            // Assert
            Assert.IsInstanceOf<UserWishVenue>(type);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateVenueCollection_OnInit()
        {
            // Arrange & Act
            var wish = new UserWishVenue();

            // Assert
            Assert.IsNotNull(wish.Venues);
        }

        [Test]
        public void ParameterlessConstructor_MustSetIsHiddenToFalse_OnInit()
        {
            // Arrange & Act
            var wish = new UserWishVenue();

            // Assert
            Assert.IsFalse(wish.IsHidden);
        }


        [Test]
        public void ParameterlessConstructor_MustNotSetUserId_OnInit()
        {
            // Arrange & Act
            var wish = new UserWishVenue();

            // Assert
            Assert.AreEqual(Guid.Empty, wish.UserId);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetUser_OnInit()
        {
            // Arrange & Act
            var wish = new UserWishVenue();

            // Assert
            Assert.IsNull(wish.User);
        }

        [Test]
        public void UserWishVenuePropertyUserId_MustBeSetCorectly()
        {
            // Arrange
            var wish = new UserWishVenue();
            var userGuid = Guid.NewGuid();

            // Act
            wish.UserId = userGuid;

            // Assert
            Assert.AreEqual(userGuid, wish.UserId);
        }

        [Test]
        public void UserWishVenuePropertyVenue_MustBeSetCorectly()
        {
            // Arrange
            var wish = new UserWishVenue();
            var venues = new HashSet<Venue>();

            // Act
            wish.Venues = venues;

            // Assert
            Assert.AreEqual(venues, wish.Venues);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void UserWishVenuePropertyIsHidden_MustBeSetCorectly(bool option)
        {
            // Arrange
            var wish = new UserWishVenue();

            // Act
            wish.IsHidden = option;

            // Assert
            Assert.AreEqual(option, wish.IsHidden);
        }

        [Test]
        public void UserWishVenuePropertyId_MustBeSetCorectly()
        {
            // Arrange
            var wish = new UserWishVenue();
            var userGuid = Guid.NewGuid();

            // Act
            wish.UserId = userGuid;

            // Assert
            Assert.AreEqual(userGuid, wish.UserId);
        }

        [Test]
        public void UserWishVenue_IsImplementHisInterfaces()
        {
            // Act & Arrange & Assert
            Assert.IsNotNull(typeof(UserWishVenue).GetInterfaces().SingleOrDefault(i => i == typeof(IDbModel)));
        }
    }
}
