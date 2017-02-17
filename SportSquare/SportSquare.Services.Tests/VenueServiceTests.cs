using AutoMapper;
using Moq;
using NUnit.Framework;
using SportSquare.Data.Contracts;
using SportSquare.Models;
using SportSquare.MVP;
using SportSquare.MVP.App_Start.AutomapperProfiles;
using SportSquareDTOs;
using System;

namespace SportSquare.Services.Tests
{
    [TestFixture]
    public class VenueServiceTests
    {
        [SetUp]
        public void Init()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VenueDTO, Venue>();
                cfg.AddProfile<VenueProfiles>();
            });

        }

        [Test]
        public void ConstructorShouldThrowIfRepositoryIsNull()
        {
            var message = "Value cannot be null.\r\nParameter name: venueRepository";
            var ex = Assert.Throws<ArgumentNullException>(() => new VenueService(null));
            Assert.AreEqual(message, ex.Message);
        }


        [Test]
        public void FilterVenuesShouldCallVenueRepositoryOnce()
        {
            var mapper = new Mock<IMapper>();
            var mockedRepo = new Mock<IVenueRepository>();
            mockedRepo.Setup(x => x.FilterVenues(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var service = new VenueService(mockedRepo.Object);
            service.FilterVenues(It.IsAny<string>(), It.IsAny<string>());
            mockedRepo.Verify(x=>x.FilterVenues(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
        [Test]
        public void FilterVenuesShouldCallVenueRepositoryWithSameFilter()
        {
            var filter = "filter";
            var mockedRepo = new Mock<IVenueRepository>();
            mockedRepo.Setup(x => x.FilterVenues(filter, It.IsAny<string>())).Verifiable();
            var service = new VenueService(mockedRepo.Object);
            service.FilterVenues(filter, filter);
            mockedRepo.Verify(x => x.FilterVenues(It.Is<string>(arg=>arg==filter), It.IsAny<string>()), Times.Once);
        }
        [Test]
        public void FilterVenuesShouldCallVenueRepositoryWithSameLocationFilter()
        {
            var locationFilter = "filter";
            var mockedRepo = new Mock<IVenueRepository>();
            mockedRepo.Setup(x => x.FilterVenues(It.IsAny<string>(), locationFilter)).Verifiable();
            var service = new VenueService(mockedRepo.Object);
            mockedRepo.Verify(x => x.FilterVenues(It.IsAny<string>(),It.Is<string>(arg => arg == locationFilter)), Times.Once);
        }

    }
}
