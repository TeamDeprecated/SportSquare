using AutoMapper;
using Moq;
using NUnit.Framework;
using SportSquare.Data.Contracts;
using SportSquare.Models;
using SportSquare.Models.Factories;
using SportSquare.MVP;
using SportSquare.MVP.App_Start.AutomapperProfiles;
using SportSquareDTOs;
using System;
using System.Linq;
using System.Linq.Expressions;

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
            var message = "Value cannot be null.\r\nParameter name: Repository cannot be null!";
            var ex = Assert.Throws<ArgumentNullException>(() => new VenueService(null, null, null));
            Assert.AreEqual(message, ex.Message);
        }

        [Test]
        public void FilterVenuesShouldCallVenueRepositoryOnce()
        {
            var mapper = new Mock<IMapper>();
            var mockedRepo = new Mock<IGenericRepository<Venue>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactoy = new Mock<IVenueFactory>();
            mockedRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Venue, bool>>>())).Verifiable();
            var service = new VenueService(mockedRepo.Object, mockedUnitOfWork.Object, mockedFactoy.Object);
            service.FilterVenues(It.IsAny<string>(), It.IsAny<string>());
            mockedRepo.Verify(x => x.GetAll(It.IsAny<Expression<Func<Venue, bool>>>()), Times.Once);
        }

        //[Test]
        //public void FilterVenuesShouldCallVenueRepositoryWithSameFilter()
        //{
        //    var mapper = new Mock<IMapper>();
        //    var mockedRepo = new Mock<IGenericRepository<Venue>>();
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var mockedFactoy = new Mock<IVenueFactory>();
        //    var location = "Sofia";
        //    var filter = "filter";
        //    Expression<Func<Venue, bool>> expexted = x => x.City == location && x.VenueTypes.Any(vt => vt.Name.Contains(filter));
        //    mockedRepo.Setup(x => x.GetAll(expexted)).Verifiable();
        //    var service = new VenueService(mockedRepo.Object, mockedUnitOfWork.Object, mockedFactoy.Object);
        //    service.FilterVenues(location, filter);
        //    mockedRepo.Verify(x => x.GetAll(It.Is<Expression<Func<Venue,bool>>>(arg=>arg==expexted)), Times.Once);
        //}
        //[Test]
        //public void FilterVenuesShouldCallVenueRepositoryWithSameLocationFilter()
        //{
        //    var locationFilter = "filter";
        //    var mockedRepo = new Mock<IVenueRepository>();
        //    mockedRepo.Setup(x => x.FilterVenues(It.IsAny<string>(), locationFilter)).Verifiable();
        //    var service = new VenueService(mockedRepo.Object);
        //    service.FilterVenues(locationFilter, locationFilter);
        //    mockedRepo.Verify(x => x.FilterVenues(It.IsAny<string>(),It.Is<string>(arg => arg == locationFilter)), Times.Once);
        //}

    }
}
