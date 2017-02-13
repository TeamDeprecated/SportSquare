using System;
using NUnit.Framework;
using SportSquare.MVP.Models.Search;
using Moq;

namespace SportSquare.MVP.Tests.Models
{
    [TestFixture]
    public class SearchEventArgsTests
    {
        const string SearchEventArgsFilterExceptionMessage = "Value cannot be null.\r\nParameter name: filter";
        const string SearchEventArgsLocationExceptionMessage = "Value cannot be null.\r\nParameter name: locationFilter";

        [Test]
        public void SearchEventArgsConstructorIfFilterNullIsPassedFilterPropertyIsEmptyString()
        {
            var actualInstance=new SearchEventArgs(null, It.IsAny<string>());
            Assert.That(actualInstance, Is.Not.Null);
            Assert.That(actualInstance.Filter, Is.EqualTo(string.Empty));
        }
        [Test]
        public void SearchEventArgsConstructorIfLocationNullIsPassedLocationPropertyIsEmptyString()
        {
            var actualInstance = new SearchEventArgs(It.IsAny<string>(),null);
            Assert.That(actualInstance, Is.Not.Null);
            Assert.That(actualInstance.LocationFilter, Is.EqualTo(string.Empty));
        }


        [Test]
        public void SearchEventInalizedCorectly_NewInstanceIsCreated()
        {
            var actualInstance = new SearchEventArgs(It.IsAny<string>(), It.IsAny<string>());
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void SearchEventFilterPropertiesCanBeGetedAndIsSame()
        {
            const string filter = "fitnes";
            var actualInstance = new SearchEventArgs(filter, It.IsAny<string>());
            Assert.AreEqual(actualInstance.Filter, filter);
        }
        [Test]
        public void SearchEventLocationPropertiesCanBeGetedAndIsSame()
        {
            const string filter = "fitnes";
            var actualInstance = new SearchEventArgs(filter, It.IsAny<string>());
            Assert.AreEqual(actualInstance.Filter, filter);
        }
    }
}
