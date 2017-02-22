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
    public class GetVenueDetailsEventArgsTests
    {
        const int Id = 45;
        [Test]
        public void ConstructorCreate_NewInstance()
        {

            var actualInstance = new GetVenueDetailsEventArgs(Id);
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void ConstructorCreateCorectly_NewInstanceOfSameType()
        {
            var actualInstance = new GetVenueDetailsEventArgs(Id);
            Assert.IsInstanceOf(typeof(GetVenueDetailsEventArgs), actualInstance);
        }

        [Test]
        public void ConstructorSetcorrectyUserId()
        {
            var actualInstance = new GetVenueDetailsEventArgs(Id);
            Assert.AreEqual(Id, actualInstance.Id);
        }
    }
}
