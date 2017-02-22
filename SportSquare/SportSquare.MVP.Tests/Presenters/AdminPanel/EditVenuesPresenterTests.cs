using Moq;
using NUnit.Framework;
using SportSquare.MVP.Models.AdminPanel;
using SportSquare.MVP.Models.Search;
using SportSquare.MVP.Models.VenueDetails;
using SportSquare.MVP.Presenters.AdminPanel;
using SportSquare.MVP.Views.AdminPanel;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.MVP.Tests.Presenters.AdminPanel
{
    [TestFixture]
    class EditVenuesPresenterTests
    {
        [Test]
        public void ConstructorShouldThrowIfVenueServiceIsNull()
        {
            var mockedview = new Mock<IEditVenuesView>();
            Assert.Throws<ArgumentNullException>(() => new EditVenuesPresenter(mockedview.Object, null));
        }
        [Test]
        public void ConstructorInalizedCorectly_NewInstanceIsCreated()
        {
            var mockedview = new Mock<IEditVenuesView>();
            var mockService= new Mock<IVenueService>();
            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void ConstructorInalizedCorectly_NewInstanceOfEditVenuesPresenterCreated()
        {
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);
            Assert.That(actualInstance, Is.InstanceOf<EditVenuesPresenter>());

        }
        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueOnce()
        {
            string expectedString= "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString), Times.Once);
        }

        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectId()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(It.Is<string>(y=>y==expectedString), expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString), Times.Once);
        }

        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectLatitude()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, It.Is<double>(y => y == expectedDouble), expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString), Times.Once);
        }
        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectLongitude()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, It.Is<double>(y => y == expectedDouble), expectedString, expectedString, expectedString, expectedString, expectedString, expectedString), Times.Once);
        }

        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectName()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, It.Is<string>(y => y == expectedString), expectedString, expectedString, expectedString, expectedString, expectedString), Times.Once);
        }
        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectPhone()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, It.Is<string>(y => y == expectedString), expectedString, expectedString, expectedString, expectedString), Times.Once);
        }
        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectWebAddress()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString,  expectedString, It.Is<string>(y => y == expectedString), expectedString, expectedString, expectedString), Times.Once);
        }
        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectAddress()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString,  expectedString, It.Is<string>(y => y == expectedString), expectedString, expectedString), Times.Once);
        }

        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectCity()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString,  expectedString, It.Is<string>(y => y == expectedString), expectedString), Times.Once);
        }
        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectImage()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, It.Is<string>(y => y == expectedString)), Times.Once);
        }
        [Test]
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithNullImage()
        {
            string expectedString = "expectedstring";
            double expectedDouble = 2.02;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, null));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString,expectedString, It.IsAny<string>()), Times.Once);
        }




        [Test]
        public void View_GetVenuesByIdSholdCallVenueServiceGetVenueOnce()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.GetVenue(anyInt));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.VenueDetailsId += null, new StringEventArgs(anyString));
            mockService.Verify(x => x.GetVenue(anyInt), Times.Once);
        }

        [Test]
        public void View_GetVenuesByIdSholdCallVenueServiceGetVenueWithCorrectId()
        {
            string anyString = "2";
            int anyInt = 2;
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.GetVenue(anyInt));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.VenueDetailsId += null, new StringEventArgs(anyString));
            mockService.Verify(x => x.GetVenue(It.Is<int>(y=>y==anyInt)), Times.Once);
        }


        [Test]
        public void View_QueryEventSholdCallVenueServiceFilterVenuesOnce()
        {
            string anyString = "2";
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.FilterVenues(anyString,anyString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.QueryEvent += null, new SearchEventArgs(anyString,anyString));
            mockService.Verify(x=>x.FilterVenues(anyString,anyString),Times.Once);
        }

        [Test]
        public void View_QueryEventSholdCallVenueServiceFilterVenuesWithCorrectFilter()
        {
            string anyString = "2";
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.FilterVenues(anyString, anyString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.QueryEvent += null, new SearchEventArgs(anyString, anyString));
            mockService.Verify(x => x.FilterVenues(It.Is<string>(y => y == anyString), anyString), Times.Once);
        }

        [Test]
        public void View_QueryEventSholdCallVenueServiceFilterVenuesWithCorrectLocationFilter()
        {
            string anyString = "2";
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.FilterVenues(anyString, anyString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.QueryEvent += null, new SearchEventArgs(anyString, anyString));
            mockService.Verify(x => x.FilterVenues( anyString, It.Is<string>(y => y == anyString)), Times.Once);
        }
    }
}
