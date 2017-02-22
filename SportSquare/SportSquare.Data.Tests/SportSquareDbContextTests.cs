using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using SportSquare.Data.Contracts;
using SportSquare.Models;

namespace SportSquare.Data.Tests
{
    [TestFixture]
    public class SportSquareDbContextTests
    {

        [Test]
        public void ShouldHave_DefaultParameterlessCtor()
        {
            // Arrange
            var db = typeof(SportSquareDbContext);
            var defaultCtorProps = new Type[] { };
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act
            var ctor = db.GetConstructor(binding, null, defaultCtorProps, null);

            // Assert
            Assert.That(ctor, Is.Not.Null);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateSportSquareDbContext()
        {
            // Arrange & Act
            var db = new SportSquareDbContext();

            // Assert
            Assert.IsInstanceOf<DbContext>(db);
        }

        [Test]
        public void SportSquareDbContext_IsImplementHisInterfaces()
        {
            // Arrange & Act & Assert
            Assert.IsNotNull(typeof(SportSquareDbContext).GetInterfaces().SingleOrDefault(i => i == typeof(ISportSquareDbContext)));
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_Venues()
        {
            // Arrange 
            var db = new SportSquareDbContext();
            var propertyName = "Venues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var venuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(venuesProperty, Is.Not.Null);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_VenuesAsVirtualProp()
        {
            // Arrange 
            var db = new SportSquareDbContext();
            var propertyName = "Venues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var venuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(venuesProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_VenuesAsVirtualProp_OfTypeIDbSetVenues()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Venues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var venuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(venuesProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Venue>)));
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_VenueTypes()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "VenueTypes";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var venueTypeProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(venueTypeProperty, Is.Not.Null);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_VenueTypesAsVirtualProp()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "VenueTypes";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var venueTypeProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(venueTypeProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_VenueTypesAsVirtualProp_OfTypeIDbSetVenueTypes()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "VenueTypes";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var venueTypeProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(venueTypeProperty.PropertyType, Is.EqualTo(typeof(IDbSet<VenueType>)));
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_Ratings()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Ratings";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var ratingProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(ratingProperty, Is.Not.Null);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_RatingsAsVirtualProp()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Ratings";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var ratingProperty = db.GetType().GetProperty(propertyName, binding);

            Assert.That(ratingProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_RatingsAsVirtualProp_OfTypeIDbSetRatings()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Ratings";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var ratingProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(ratingProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Rating>)));
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_Users()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Users";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var usersProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(usersProperty, Is.Not.Null);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_UsersAsVirtualProp()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Users";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var usersProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(usersProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_UsersAsVirtualProp_OfTypeIDbSetUsers()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Users";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var usersProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(usersProperty.PropertyType, Is.EqualTo(typeof(IDbSet<User>)));
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_UserWishVenues()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "UserWishVenues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var userWishVenuesProperty = db.GetType().GetProperty(propertyName, binding);

            Assert.That(userWishVenuesProperty, Is.Not.Null);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_UserWishVenuesAsVirtualProp()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "UserWishVenues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var userWishVenuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(userWishVenuesProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_UserWishVenuesAsVirtualProp_OfTypeIDbSetUserWishVenues()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "UserWishVenues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var userWishVenuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(userWishVenuesProperty.PropertyType, Is.EqualTo(typeof(IDbSet<UserWishVenue>)));
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_UserFavoriteVenues()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "UserFavoriteVenues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var userFavoriteVenuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(userFavoriteVenuesProperty, Is.Not.Null);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_UserFavoriteVenuesAsVirtualProp()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "UserFavoriteVenues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var userFavoriteVenuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(userFavoriteVenuesProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_UserFavoriteVenuesAsVirtualProp_OfTypeIDbSetUserFavoriteVenues()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "UserFavoriteVenues";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var userFavoriteVenuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(userFavoriteVenuesProperty.PropertyType, Is.EqualTo(typeof(IDbSet<UserFavoriteVenue>)));
        }

        public void DbContext_ShouldCreate_ValidInstanceOf_Comments()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Comments";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var userFavoriteVenuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(userFavoriteVenuesProperty, Is.Not.Null);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_CommentsAsVirtualProp()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Comments";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var userFavoriteVenuesProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(userFavoriteVenuesProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void DbContext_ShouldCreate_ValidInstanceOf_CommentsAsVirtualProp_OfTypeIDbSetComments()
        {
            // Arrange
            var db = new SportSquareDbContext();
            var propertyName = "Comments";
            var binding = BindingFlags.Public | BindingFlags.Instance;

            // Act 
            var commentsProperty = db.GetType().GetProperty(propertyName, binding);

            // Assert
            Assert.That(commentsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Comment>)));
        }
    }
}
