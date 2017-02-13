using System;
using NUnit.Framework;
using Moq;
using SportSquare.MVP.Views;
using SportSquare.MVP.Presenters;
using SportSquare.Services.Contracts;

namespace SportSquare.MVP.Tests.Presenters
{
    [TestFixture]
    public class HomePresenterTests
    {
        const string GathererExceptionMessage = "Value cannot be null.\r\nParameter name: gatherer";
        [Test]
        public void HomePresenterInitializedWithNullGatherer()
        {
            var mockedHomeView = new Mock<IHomeView>();
            var ex = Assert.Throws<ArgumentNullException>(() => new HomePresenter(mockedHomeView.Object, null));
            Assert.That(ex.Message, Is.EqualTo(GathererExceptionMessage));
        }

        [Test]
        public void HomePresenterInalizedCorectly_NewInstanceIsCreated()
        {
            var mockedHomeView = new Mock<IHomeView>();
            var mockedIpInfoGatherer = new Mock<IipInfoGatherer>();
            var actualInstance = new HomePresenter(mockedHomeView.Object, mockedIpInfoGatherer.Object);
            Assert.That(actualInstance, Is.Not.Null);
        }
        [Test]
        public void HomePresenterInalizedCorectly_NewHomePresenterInstanceIscreated()
        {
            var mockedHomeView = new Mock<IHomeView>();
            var mockedIpInfoGatherer = new Mock<IipInfoGatherer>();
            var actualInstance = new HomePresenter(mockedHomeView.Object, mockedIpInfoGatherer.Object);
            Assert.That(actualInstance, Is.InstanceOf<HomePresenter>());
        }

        [Test]
        public void WhenHomePresenterIsInitialized_IIpy_ShouldCall_GetLoginServiceExactlyOnce()
        {
        }
    }
}