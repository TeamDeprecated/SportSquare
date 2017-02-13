using System;
using NUnit.Framework;
using Moq;
using SportSquare.MVP.Views;
using SportSquare.MVP.Presenters;
using SportSquare.Services.Contracts;
using SportSquare.MVP.Models;

namespace SportSquare.MVP.Tests.Presenters
{
    [TestFixture]
    public class HomePresenterTests
    {
        const string GathererExceptionMessage = "Value cannot be null.\r\nParameter name: gatherer";
        const string constIPaddress = "0.0.0.0";

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
        public void IpDetailsShouldCallGathererSeriveceGetUserCityByIpMethodOnce()
        {
            var mockedHomeView = new Mock<IHomeView>();
            var mockedIipGathererService = new Mock<IipInfoGatherer>();
            var mockedModel = new Mock<HomeViewModel>();

            mockedHomeView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedIipGathererService.Setup(x => x.GetUserCityByIp("")).Returns("");

            var homePresenter = new HomePresenter(mockedHomeView.Object, mockedIipGathererService.Object);
            mockedHomeView.Raise(x => x.IpDetails += null, null, new HomeEventArgs(constIPaddress));

            mockedIipGathererService.Verify(x=>x.GetUserCityByIp(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void IpDetailsShouldCallGathererSeriveceGetUserCityByIpWithCorrectIp()
        {
            //TODO fix this test
            var mockedHomeView = new Mock<IHomeView>();
            var mockedIipGathererService = new Mock<IipInfoGatherer>();
            var mockedModel = new Mock<HomeViewModel>();

            mockedHomeView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedIipGathererService.Setup(x => x.GetUserCityByIp("")).Returns("");

            var homePresenter = new HomePresenter(mockedHomeView.Object, mockedIipGathererService.Object);
            mockedHomeView.Raise(x => x.IpDetails += null, null, new HomeEventArgs(constIPaddress));

      

        mockedIipGathererService.Verify(x => x.GetUserCityByIp(It.Is<string>(arg => arg ==constIPaddress  )));
        }
    }
}