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
   public  class GenericVenueDetailsEventArgsTests
    {
        const string userId = "45";
        const string venueId = "55";
        [Test]
        public void ConstructorCreate_NewInstance()
        {
           
            var actualInstance = new GenericVenueDetailsEventArgs(userId, venueId);
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void ConstructorCreateCorectly_NewInstanceOfSameType()
        {
            var actualInstance = new GenericVenueDetailsEventArgs(userId, venueId);
            Assert.IsInstanceOf(typeof(GenericVenueDetailsEventArgs), actualInstance);
        }

        [Test]
        public void ConstructorSetcorrectyUserId()
        {
            var actualInstance = new GenericVenueDetailsEventArgs(userId, venueId);
            Assert.AreEqual(userId, actualInstance.UserID);
        }


        [Test]
        public void ConstructorSetcorrectyVenueId()
        {
            var actualInstance = new GenericVenueDetailsEventArgs(userId, venueId);
            Assert.AreEqual(venueId, actualInstance.VenueId);
        }
    }
}
