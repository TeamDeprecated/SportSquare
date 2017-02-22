using System;
using NUnit.Framework;
using SportSquare.MVP.Views;
using Moq;
using SportSquare.MVP.Presenters;
using SportSquare.Services.Contracts;
using SportSquare.MVP.Models.Search;
using System.Collections.Generic;
using SportSquareDTOs;
using SportSquare.MVP.Models.VenueDetails;

namespace SportSquare.MVP.Tests.Presenters
{
    [TestFixture]
    public class SearchPresenterTests
    {
        const string constIPaddress = "0.0.0.0";
        const string constFilter = "0.0.0.0";

        [Test]
        public void SearchPresenterInitializedWithNullVenueService()
        {
            var mockedHomeView = new Mock<ISearchView>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var ex = Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedHomeView.Object, null, mockedWishListService.Object, mockedRatingService.Object));
        }
        [Test]
        public void SearchPresenterInitializedWithWishListService()
        {
            var mockedHomeView = new Mock<ISearchView>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedVenueService = new Mock<IVenueService>();
            var ex = Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedHomeView.Object, mockedVenueService.Object, null, mockedRatingService.Object));
        }
        [Test]
        public void SearchPresenterInitializedWithRatingServiceNull()
        {
            var mockedHomeView = new Mock<ISearchView>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedVenueService = new Mock<IVenueService>();
            var ex = Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedHomeView.Object, mockedVenueService.Object, mockedWishListService.Object, null));
        }

        [Test]
        public void SearchPresenterInalizedCorectly_NewInstanceIsCreated()
        {
            var mockedHomeView = new Mock<ISearchView>();
            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var actualInstance = new SearchPresenter(mockedHomeView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            Assert.That(actualInstance, Is.Not.Null);
        }
        [Test]
        public void SearchPresenterInalizedCorectly_NewSearchPresenterInstanceIscreated()
        {
            var mockedHomeView = new Mock<ISearchView>();
            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var actualInstance = new SearchPresenter(mockedHomeView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            Assert.That(actualInstance, Is.InstanceOf<SearchPresenter>());
        }

        [Test]
        public void View_QueryEventShouldCallVenueSeriveceFilterVenuesMethodOnce()
        {
            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedModel = new Mock<SearchViewModel>();

            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedVenueService.Setup(x => x.FilterVenues(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<IEnumerable<VenueDTO>>());

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            mockedSearchView.Raise(x => x.QueryEvent += null, new SearchEventArgs(It.IsAny<string>(), It.IsAny<string>()));

            mockedVenueService.Verify(x => x.FilterVenues(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }
        
        //TODO test this case as well
        //[Test]
        //public void View_QueryEventShouldCallVenueSeriveceFilterVenuesMethodWithCorrectParameters()
        //{
        //    //TODO fix this test
        //    var mockedSearchView = new Mock<ISearchView>();
        //    var mockedVenueService = new Mock<IVenueService>();
        //    var mockedModel = new Mock<SearchViewModel>();


        //    mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
        //    mockedVenueService.Setup(x => x.FilterVenues(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

        //    var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object);
        //    mockedSearchView.Raise(x => x.QueryEvent += null, new SearchEventArgs(constIPaddress, constFilter));

        //    mockedVenueService.Verify(x => x.FilterVenues(It.Is<string>(arg => arg == constIPaddress), It.Is<string>(arg => arg == constFilter)), Times.Once);
        //}

        [Test]
        public void View_UpdateRatingSouldCallRatingServiceOnce()
        {

            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedModel = new Mock<SearchViewModel>();

            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedRatingService.Setup(x => x.AddRating(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()));

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            mockedSearchView.Raise(x => x.UpdateRating += null, new UpdateRatingEventArgs(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            mockedRatingService.Verify(x => x.AddRating(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void View_UpdateRatingSouldCallRatingServiceWithCorrectUserId()
        {

            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedModel = new Mock<SearchViewModel>();
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";
            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedRatingService.Setup(x => x.AddRating(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()));

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            mockedSearchView.Raise(x => x.UpdateRating += null, new UpdateRatingEventArgs(mockedGuidString, It.IsAny<string>(), It.IsAny<string>()));

            mockedRatingService.Verify(x => x.AddRating(It.Is<Guid>(args => args == mockedGuid), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        [TestCase("5", 5)]
        [TestCase("0", 0)]
        [TestCase("10000", 10000)]
        [TestCase("15", 15)]
        public void View_UpdateRatingSouldCallRatingServiceWithCorrectVenueId(string mockedVenueString, int mockedVenueInt)
        {

            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedModel = new Mock<SearchViewModel>();
            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedRatingService.Setup(x => x.AddRating(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()));

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            mockedSearchView.Raise(x => x.UpdateRating += null, new UpdateRatingEventArgs(It.IsAny<string>(), mockedVenueString, It.IsAny<string>()));

            mockedRatingService.Verify(x => x.AddRating(It.IsAny<Guid>(), It.Is<int>(args => args == mockedVenueInt), It.IsAny<int>()), Times.Once);
        }

        [Test]
        [TestCase("5", 5)]
        [TestCase("0", 0)]
        [TestCase("10000", 10000)]
        [TestCase("15", 15)]
        public void View_UpdateRatingSouldCallRatingServiceWithCorrectRating(string mockedRatingString, int mockedRatingInt)
        {

            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedModel = new Mock<SearchViewModel>();
            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedRatingService.Setup(x => x.AddRating(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()));

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            mockedSearchView.Raise(x => x.UpdateRating += null, new UpdateRatingEventArgs(It.IsAny<string>(), mockedRatingString, It.IsAny<string>()));

            mockedRatingService.Verify(x => x.AddRating(It.IsAny<Guid>(), It.Is<int>(args => args == mockedRatingInt), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void View_SaveVenueEventShouldCallwishListServiceOnce()
        {

            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedModel = new Mock<SearchViewModel>();
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedWishListService.Setup(x => x.UpdateWishList(It.IsAny<Guid>(), It.IsAny<int>())).Verifiable();

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            mockedSearchView.Raise(x => x.SaveVenueEvent += null, new SaveVenueArgs(mockedGuidString, ""));

            mockedWishListService.Verify(x => x.UpdateWishList(mockedGuid, It.IsAny<int>()), Times.Exactly(1));
        }

        [Test]
        public void View_SaveVenueEventShouldCallwishListServiceWithCorrectUser()
        {

            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedModel = new Mock<SearchViewModel>();
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";
            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedWishListService.Setup(x => x.UpdateWishList(It.IsAny<Guid>(),1));

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            mockedSearchView.Raise(x => x.SaveVenueEvent += null, new SaveVenueArgs(mockedGuidString, ""));

            mockedWishListService.Verify(x => x.UpdateWishList(It.Is<Guid>(arg => arg == mockedGuid), It.IsAny<int>()), Times.Once);
        }

        [Test]
        [TestCase("5", 5)]
        [TestCase("0", 0)]
        [TestCase("10000", 10000)]
        [TestCase("15", 15)]
        public void View_SaveVenueEventShouldCallwishListServiceWithCorrectVenue(string mockedVenueString, int mockedVenueInt)
        {
            var mockedSearchView = new Mock<ISearchView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedWishListService = new Mock<IWishListService>();
            var mockedModel = new Mock<SearchViewModel>();

            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            mockedSearchView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedWishListService.Setup(x => x.UpdateWishList(mockedGuid, mockedVenueInt));

            var searchPresenter = new SearchPresenter(mockedSearchView.Object, mockedVenueService.Object, mockedWishListService.Object, mockedRatingService.Object);
            mockedSearchView.Raise(x => x.SaveVenueEvent += null, new SaveVenueArgs(mockedGuidString, mockedVenueString));

            mockedWishListService.Verify(x => x.UpdateWishList(mockedGuid, mockedVenueInt), Times.Once);

        }

    }
}
