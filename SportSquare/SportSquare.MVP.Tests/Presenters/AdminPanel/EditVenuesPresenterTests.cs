using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using SportSquare.MVP.Models.AdminPanel;
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
            Fixture fixture = new Fixture();
            string expectedString= fixture.Create<string>();
            double expectedDouble = fixture.Create<double>();
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
        public void View_UpdateVenueDetailsSholdCallVenueServiceUpdateVenueWithCorrectParameters()
        {
            Fixture fixture = new Fixture();
            string expectedString = fixture.Create<string>();
            double expectedDouble = fixture.Create<double>();
            var mockedview = new Mock<IEditVenuesView>();
            var mockService = new Mock<IVenueService>();
            var mockedModel = new Mock<EditVenuesViewModel>();
            mockedview.Setup(x => x.Model).Returns(mockedModel.Object);
            mockService.Setup(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));

            var actualInstance = new EditVenuesPresenter(mockedview.Object, mockService.Object);

            mockedview.Raise(x => x.UpdateVenueDetails += null, new UpdateVenueEventArgs(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString));
            mockService.Verify(x => x.UpdateVenue(expectedString, expectedDouble, expectedDouble, expectedString, expectedString, expectedString, expectedString, expectedString, expectedString), Times.Once);
        }
    }
}
