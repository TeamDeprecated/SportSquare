using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using SportSquare.Models.Contracts;

namespace SportSquare.Models.Tests
{
    [TestFixture]
    public class VenueTypeTests
    {
        [Test]
        public void ParameterlessConstructor_MustCreateVenueType()
        {
            // Arrange & Act
            var type = new VenueType();

            // Assert
            Assert.IsInstanceOf<VenueType>(type);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateVenueCollection_OnInit()
        {
            // Arrange & Act
            var type = new VenueType();

            // Assert
            Assert.IsNotNull(type.Venues);
        }

        [Test]
        public void ParameterlessConstructor_MustSetIsHiddenToFalse_OnInit()
        {
            // Arrange & Act
            var type = new VenueType();

            // Assert
            Assert.IsFalse(type.IsHidden);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetId_OnInit()
        {
            // Arrange & Act
            var type = new VenueType();

            // Assert
            Assert.AreEqual(0, type.Id);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetName_OnInit()
        {
            // Arrange & Act
            var type = new VenueType();

            // Assert
            Assert.IsNull(type.Name);
        }

        [Test]
        public void VenueTypePropertyId_MustBeSetCorectly()
        {
            // Arrange
            var type = new VenueType();
            var id = 0;

            // Act
            type.Id = id;

            // Assert
            Assert.AreEqual(id, type.Id);
        }

        [Test]
        public void VenueTypePropertyName_MustBeSetCorectly()
        {
            // Arrange
            var type = new Venue();
            var name = "Gogo";

            // Act
            type.Name = name;

            // Assert
            Assert.AreEqual(name, type.Name);
        }

        [Test]
        public void VenueTypePropertyVenues_MustBeSetCorectly()
        {
            // Arrange
            var type = new VenueType();
            var venues = new List<Venue>();

            // Act
            type.Venues = venues;

            // Assert
            Assert.AreEqual(venues, type.Venues);
        }

        [Test]
        public void IsVenueTypeImplementHisInterfaces()
        {
            // Act & Arrange & Assert
            Assert.IsNotNull(typeof(VenueType).GetInterfaces().SingleOrDefault(i => i == typeof(IDbModel)));
        }
    }
}
