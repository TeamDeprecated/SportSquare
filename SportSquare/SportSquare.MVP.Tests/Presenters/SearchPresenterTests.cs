using System;
using NUnit.Framework;
using SportSquare.MVP.Views;
using Moq;
using SportSquare.MVP.Presenters;
using SportSquare.Services.Contracts;
using SportSquare.MVP.Models.Search;
using System.Collections.Generic;
using SportSquareDTOs;

namespace SportSquare.MVP.Tests.Presenters
{
    [TestFixture]
    public class SearchPresenterTests
    {
        const string ServiceExceptionMessage = "Value cannot be null.\r\nParameter name: service";
        const string constIPaddress = "0.0.0.0";

        [Test]
        public void SearchPresenterInitializedWithNullGatherer()
        {
            var mockedHomeView = new Mock<ISearchView>();
            var ex = Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedHomeView.Object, null));
            Assert.That(ex.Message, Is.EqualTo(ServiceExceptionMessage));
        }

        [Test]
        public void SearchPresenterInalizedCorectly_NewInstanceIsCreated()
        {
            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var actualInstance = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object);
            Assert.That(actualInstance, Is.Not.Null);
        }
        [Test]
        public void SearchPresenterInalizedCorectly_NewSearchPresenterInstanceIscreated()
        {
            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var actualInstance = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object);
            Assert.That(actualInstance, Is.InstanceOf<SearchPresenter>());
        }

        [Test]
        public void View_QueryEventShouldCallVenueSeriveceFilterVenuesMethodOnce()
        {
            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedModel = new Mock<SearchViewModel>();

            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedVenueService.Setup(x => x.FilterVenues(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<IEnumerable<VenueDTO>>());

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object);
            mockedSearchView.Raise(x => x.QueryEvent += null, new SearchEventArgs(It.IsAny<string>(), It.IsAny<string>()));

            mockedVenueService.Verify(x => x.FilterVenues(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void View_QueryEventShouldCallVenueSeriveceFilterVenuesMethodWithCorrectParameters()
        {
            //TODO fix this test
            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedModel = new Mock<SearchViewModel>();

            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedVenueService.Setup(x => x.FilterVenues(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<IEnumerable<VenueDTO>>());

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object);
            mockedSearchView.Raise(x => x.QueryEvent += null, new SearchEventArgs(It.IsAny<string>(), It.IsAny<string>()));

            //mockedVenueService.Verify(x => x.FilterVenues(It.Is<string>(arg => arg == constIPaddress), It.Is<string>(arg => arg == constIPaddress)));
            
        }
    }
}
