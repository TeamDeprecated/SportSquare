using Moq;
using NUnit.Framework;
using SportSquare.MVP.Models.VenueDetails;
using SportSquare.MVP.Presenters;
using SportSquare.MVP.Views;
using SportSquare.Services;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.MVP.Tests.Presenters
{
    [TestFixture]
    public class VenueDetailsPresenterTests
    {
        [Test]
        public void ConstructorShouldThrowIfVenueServiceIsNull()
        {
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            Assert.Throws<ArgumentNullException>(() => new VenueDetailsPresenter(mockedView.Object, null, mockedCommentService.Object, mockedRatingService.Object));
        }

        [Test]
        public void ConstructorShouldThrowIfCommentServiceIsNull()
        {
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedRatingService = new Mock<IRatingService>();

            Assert.Throws<ArgumentNullException>(() => new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, null, mockedRatingService.Object));
        }
        [Test]
        public void ConstructorShouldThrowIfRatingServiceIsNull()
        {
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();

            Assert.Throws<ArgumentNullException>(() => new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, null));
        }

        [Test]
        public void ConstructorShouldCreateNewInstance()
        {
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var actualInstance=new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            Assert.NotNull(actualInstance);
        }
        [Test]
        public void ConstructorShouldCreateNewInstanceOfVenueDetailsPresenter()
        {
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var actualInstance = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            Assert.IsInstanceOf(typeof(VenueDetailsPresenter), actualInstance);
        }

        [Test]
        public void View_AddCommentCallsOnceVenueServiceGetVenue()
        {
            int anyInt = 2;
            string anyString = "2";
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedVenueService.Setup(x => x.GetVenue(anyInt)).Verifiable();

            var presenter=  new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.AddComment += null, new AddCommentEventArgs(anyString, anyString, anyString));

            mockedVenueService.Verify(x => x.GetVenue(anyInt), Times.Once);
        }
        [Test]
        public void View_AddCommentCallsOnceCommentServiceCreateComment()
        {
            int anyInt = 2;
            string anyString = "2";
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedCommentService.Setup(x => x.CreateComment(new Guid(),anyInt, anyString)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.AddComment += null, new AddCommentEventArgs(anyString, anyString, anyString));

            mockedCommentService.Verify(x => x.CreateComment(new Guid(), anyInt, anyString), Times.Once);
        }

        [Test]
        public void View_AddCommentCallsVenueServiceGetVenueWithCorrectVenueId()
        {
            int anyInt = 2;
            string anyString = "2";
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedVenueService.Setup(x => x.GetVenue(anyInt)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.AddComment += null, new AddCommentEventArgs(anyString, anyString, anyString));

            mockedVenueService.Verify(x => x.GetVenue(It.Is<int>(y=>y==anyInt)), Times.Once);
        }


        [Test]
        public void View_AddCommentCallsCommentServiceCreateCommentWithCorrectUserID()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedCommentService.Setup(x => x.CreateComment(new Guid(), anyInt, anyString)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.AddComment += null, new AddCommentEventArgs(mockedGuidString, anyString, anyString));

            mockedCommentService.Verify(x => x.CreateComment(It.Is<Guid>(y=>y== mockedGuid), anyInt, anyString), Times.Once);
        }

        [Test]
        public void View_AddCommentCallsCommentServiceCreateCommentWithCorrectVenueId()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedCommentService.Setup(x => x.CreateComment(new Guid(), anyInt, anyString)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.AddComment += null, new AddCommentEventArgs(mockedGuidString, anyString, anyString));

            mockedCommentService.Verify(x => x.CreateComment(mockedGuid, It.Is<int>(y => y == anyInt), anyString), Times.Once);
        }

        [Test]
        public void View_AddCommentCallsCommentServiceCreateCommentWithCorrectComment()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedCommentService.Setup(x => x.CreateComment(new Guid(), anyInt, anyString)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.AddComment += null, new AddCommentEventArgs(mockedGuidString, anyString, anyString));

            mockedCommentService.Verify(x => x.CreateComment(mockedGuid, anyInt, It.Is<string>(y => y == anyString)), Times.Once);
        }

        [Test]
        public void View_UpdateRatingCallsAddRatingServiceAddRating()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedRatingService.Setup(x => x.AddRating(new Guid(), anyInt, anyInt)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.UpdateRating += null, new UpdateRatingEventArgs(mockedGuidString, anyString, anyString));

            mockedRatingService.Verify(x => x.AddRating(mockedGuid, anyInt, anyInt), Times.Once);
        }

        [Test]
        public void View_UpdateRatingCallsAddRatingServiceAddRatingWithCorrectUserId()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedRatingService.Setup(x => x.AddRating(new Guid(), anyInt, anyInt)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.UpdateRating += null, new UpdateRatingEventArgs(mockedGuidString, anyString, anyString));

            mockedRatingService.Verify(x => x.AddRating(It.Is<Guid>(y=>y==mockedGuid), anyInt, anyInt), Times.Once);
        }

        [Test]
        public void View_UpdateRatingCallsAddRatingServiceAddRatingWithCorrectVenueId()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedRatingService.Setup(x => x.AddRating(new Guid(), anyInt, anyInt)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.UpdateRating += null, new UpdateRatingEventArgs(mockedGuidString, anyString, anyString));

            mockedRatingService.Verify(x => x.AddRating( mockedGuid, It.Is<int>(y => y == anyInt), anyInt), Times.Once);
        }

        [Test]
        public void View_UpdateRatingCallsAddRatingServiceAddRatingWithCorrecRating()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedRatingService.Setup(x => x.AddRating(new Guid(), anyInt, anyInt)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.UpdateRating += null, new UpdateRatingEventArgs(mockedGuidString, anyString, anyString));

            mockedRatingService.Verify(x => x.AddRating(mockedGuid,  anyInt, It.Is<int>(y => y == anyInt)), Times.Once);
        }

        [Test]
        public void View_OnFormGetItemsCallsOnceVenueServiceGetVenue()
        {
            int anyInt = 2;
            string anyString = "2";
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedVenueService.Setup(x => x.GetVenue(anyInt)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.OnFormGetItems += null, new GetVenueDetailsEventArgs(anyInt));

            mockedVenueService.Verify(x => x.GetVenue(anyInt), Times.Once);
        }

        [Test]
        public void View_OnFormGetItemsCallsVenueServiceGetVenueWithCorrectVenueId()
        {
            int anyInt = 2;
            string anyString = "2";
            var mockedView = new Mock<IVenueDetailsView>();
            var mockedVenueService = new Mock<IVenueService>();
            var mockedCommentService = new Mock<ICommentService>();
            var mockedRatingService = new Mock<IRatingService>();

            var mockedModel = new Mock<VenueDetailsViewModel>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);
            mockedVenueService.Setup(x => x.GetVenue(anyInt)).Verifiable();

            var presenter = new VenueDetailsPresenter(mockedView.Object, mockedVenueService.Object, mockedCommentService.Object, mockedRatingService.Object);
            mockedView.Raise(x => x.OnFormGetItems += null, new GetVenueDetailsEventArgs(anyInt));

            mockedVenueService.Verify(x => x.GetVenue(It.Is<int>(y=>y==anyInt)), Times.Once);
        }
    }
}
