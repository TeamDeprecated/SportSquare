using Moq;
using NUnit.Framework;
using SportSquare.Services;
using SportSquare.Services.Tests;
using System;

namespace SportSquare.Services.Tests
{
    [TestFixture]
    public class IpInfoGathererTests
    {
        [Test]
        public void ConstructorShouldThrowIfModelIsNull()
        {
            const string exception = "Value cannot be null.\r\nParameter name: model";

            var ex = Assert.Throws<ArgumentNullException>(() => new IpInfoGatherer(null));
            Assert.AreEqual(exception, ex.Message);
        }

        [Test]
        public void ConstructorShouldNotThrowIfModelIsNotNull()
        {
            var model = new Mock<IpInfoGathererModel>();
            Assert.DoesNotThrow(() => new IpInfoGatherer(model.Object));
        }
        [Test]
        public void GetUserCountryByIpShouldCallCollectIpInfoOnce()
        {
            Exception exception = new Exception();
            Exception caught = null;
            var model = new Mock<IpInfoGathererModel>();
            var gatherer = new IpInfoGatherer(model.Object);
            model.SetupSet(x => x.Country = It.IsAny<String>()).Throws(exception);
            try
            {
                gatherer.GetUserCountryByIp("");
            }
            catch (Exception ex)
            {
                caught = ex;
                Assert.AreSame(exception, caught);
            }
        }

        [Test]
        public void GetUserCityByIpShouldCallCollectIpInfoOnce()
        {
            Exception exception = new Exception();
            Exception caught = null;
            var model = new Mock<IpInfoGathererModel>();
            var gatherer = new IpInfoGatherer(model.Object);
            model.SetupSet(x => x.Country = It.IsAny<String>()).Throws(exception);
            try
            {
                gatherer.GetUserCityByIp(It.IsAny<string>());
            }
            catch (Exception ex)
            {
                caught = ex;
                Assert.AreSame(exception, caught);

            }
        }

        [Test]
        public void GetUserCoordinatesByIpShouldCallCollectIpInfoOnce()
        {
            Exception exception = new Exception();
            Exception caught = null;
            var model = new Mock<IpInfoGathererModel>();
            var gatherer = new IpInfoGatherer(model.Object);
            model.SetupSet(x => x.Country = It.IsAny<String>()).Throws(exception);
            try
            {
                gatherer.GetUserCoordinatesByIp(It.IsAny<string>());
            }
            catch (Exception ex)
            {
                caught = ex;
                Assert.AreSame(exception, caught);

            }
        }
    }
}