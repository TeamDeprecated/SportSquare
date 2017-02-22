using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using SportSquare.Models.Contracts;

namespace SportSquare.Models.Tests
{
    [TestFixture]
    public class VenueTests
    {
        [Test]
        public void ConstructorWithParams_MustCreateVenue()
        {
            // Arrange 
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";

            // Act
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.IsInstanceOf<Venue>(venue);
        }

        [Test]
        public void ConstructorWithParams_MustSetRatingProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.IsNotNull(venue.Ratings);
        }


        [Test]
        public void ConstructorWithParams_MustSetUserWishVenuesProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.IsNotNull(venue.UserWishVenue);
        }

        [Test]
        public void ConstructorWithParams_MustSetCommentProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.IsNotNull(venue.Comments);
        }

        [Test]
        public void ConstructorWithParams_MustSetVenueTypeProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.IsNotNull(venue.UserWishVenue);
        }

        [Test]
        public void ConstructorWithParams_MustSet_LatitudeProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.AreEqual(latitude, venue.Latitude);
        }


        [Test]
        public void ConstructorWithParams_MustSet_LongitudeProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.AreEqual(longitude, venue.Longitude);
        }


        [Test]
        public void ConstructorWithParams_MustSet_ImageProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            var image = "01010101";
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.AreEqual(image, venue.Image);
        }


        [Test]
        public void ConstructorWithParams_MustSet_NameProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.AreEqual(name, venue.Name);
        }

        [Test]
        public void ConstructorWithParams_MustSet_PhoneProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.AreEqual(phone, venue.Phone);
        }

        [Test]
        public void ConstructorWithParams_MustSet_WebAddresProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.AreEqual(webAddress, venue.WebAddress);
        }


        [Test]
        public void ConstructorWithParams_MustSet_AddresProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.AreEqual(address, venue.Address);
        }

        [Test]
        public void ConstructorWithParams_MustSet_CityProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.AreEqual(city, venue.City);
        }

        [Test]
        public void ConstructorWithParams_MustSet_IsHiddedProperty()
        {
            // Arrange & Act
            var latitude = 44.44;
            var longitude = 22.22;
            string image = null;
            var name = "Ivan";
            string phone = "99808342";
            var webAddress = "www.wasd.com";
            var address = "Malinov 33";
            var city = "Sofia";
            var venue = new Venue(latitude, longitude, image, name, phone, webAddress, address, city);

            // Assert
            Assert.IsFalse(venue.IsHidden);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateVenue()
        {
            // Arrange * Act
            var venue = new Venue();

            // Assert
            Assert.IsInstanceOf<Venue>(venue);
        }

        [Test]
        public void ParameterlessConstructor_MustSetIsHiddenToFalse()
        {
            // Arrange & Act
            var venue = new Venue();

            // Assert
            Assert.AreEqual(false, venue.IsHidden);
        }

        [Test]
        public void ParameterlessConstructor_MustSetRatingProperty()
        {
            // Arrange & Act
            var venue = new Venue();

            // Assert
            Assert.IsNotNull(venue.Ratings);
        }


        [Test]
        public void ParameterlessConstructor_MustSetUserWishVenuesProperty()
        {
            // Arrange & Act
            var venue = new Venue();

            // Assert
            Assert.IsNotNull(venue.UserWishVenue);
        }

        [Test]
        public void ParameterlessConstructor_MustSetCommentProperty()
        {
            // Arrange & Act
            var venue = new Venue();

            // Assert
            Assert.IsNotNull(venue.Comments);
        }

        [Test]
        public void ParameterlessConstructor_MustSetVenueTypeProperty()
        {
            // Arrange & Act
            var venue = new Venue();

            // Assert
            Assert.IsNotNull(venue.UserWishVenue);
        }

        [Test]
        public void VenuePropertyId_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var id = 3;

            // Act
            venue.Id = id;

            // Assert
            Assert.AreEqual(id, venue.Id);
        }

        [Test]
        public void VenuePropertyImage_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var image = "0101001";

            // Act
            venue.Image = image;

            // Assert
            Assert.AreEqual(image, venue.Image);
        }


        [Test]
        public void VenuePropertyName_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var name = "Ivan";

            // Act
            venue.Name = name;

            // Assert
            Assert.AreEqual(name, venue.Name);
        }

        [Test]
        public void VenuePropertyLongitude_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var longitude = 22.22;
            ;

            // Act
            venue.Longitude = longitude;

            // Assert
            Assert.AreEqual(longitude, venue.Longitude);
        }

        [Test]
        public void VenuePropertyLatitude_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var latitude = 22.22;
            ;

            // Act
            venue.Latitude = latitude;

            // Assert
            Assert.AreEqual(latitude, venue.Latitude);
        }

        [Test]
        public void VenuePropertyPhone_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var phone = "+359889124";

            // Act
            venue.Phone = phone;

            // Assert
            Assert.AreEqual(phone, venue.Phone);
        }

        [Test]
        public void VenuePropertyCity_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var city = "+Sofia";

            // Act
            venue.City = city;

            // Assert
            Assert.AreEqual(city, venue.City);
        }

        [Test]
        public void VenuePropertyAddress_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var address = "Malinov 33";

            // Act
            venue.Address = address;

            // Assert
            Assert.AreEqual(address, venue.Address);
        }

        [Test]
        public void VenuePropertyWebAddress_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var webAddress = "www.nimoga.com";

            // Act
            venue.WebAddress = webAddress;

            // Assert
            Assert.AreEqual(webAddress, venue.WebAddress);
        }

        [Test]
        public void VenuePropertyVenueType_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var venueTypes = new HashSet<VenueType>();

            // Act
            venue.VenueTypes = venueTypes;

            // Assert
            Assert.AreEqual(venueTypes, venue.VenueTypes);
        }

        [Test]
        public void VenuePropertyRating_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var ratings = new HashSet<Rating>();

            // Act
            venue.Ratings = ratings;

            // Assert
            Assert.AreEqual(ratings, venue.VenueTypes);
        }

        [Test]
        public void VenuePropertyUserWishVenue_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var userWishVenues = new HashSet<UserWishVenue>();

            // Act
            venue.UserWishVenue = userWishVenues;

            // Assert
            Assert.AreEqual(userWishVenues, venue.UserWishVenue);
        }

        [Test]
        public void VenuePropertyComment_MustBeSetCorectly()
        {
            // Arrange
            var venue = new Venue();
            var comments = new HashSet<Comment>();

            // Act
            venue.Comments = comments;

            // Assert
            Assert.AreEqual(comments, venue.Comments);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void VenuePropertyIsHidden_MustBeSetCorectly(bool option)
        {
            // Arrange
            var venue = new Venue();

            // Act
            venue.IsHidden = option;

            // Assert
            Assert.AreEqual(option, venue.IsHidden);
        }

        [Test]
        public void IsVenueImplementHisInterfaces()
        {
            // Act & Arrange & Assert
            Assert.IsNotNull(typeof(Venue).GetInterfaces().SingleOrDefault(i => i == typeof(IDbModel)));
        }
    }
}
