using Moq;
using NUnit.Framework;
using SportSquare.Data.Contracts;
using SportSquare.Models;
using SportSquare.Models.Factories;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services.Tests
{
    [TestFixture]
    class RatingServiceTests
    {
        [Test]
        public void ConstructorShouldThtowIfRatingFactoryIsNull()
        {
            var repository = new Mock<IGenericRepository<Rating>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            Assert.Throws<ArgumentNullException>(() => new RatingService(repository.Object, unitOfWork.Object, null));
        }

        [Test]
        public void ConstructorShouldShoudlCreateInstanceOfRatingService()
        {
            var repository = new Mock<IGenericRepository<Rating>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var ratingFactory = new Mock<IRatingFactory>();
            var service = new RatingService(repository.Object, unitOfWork.Object, ratingFactory.Object);
            Assert.IsInstanceOf(typeof(IRatingService), service);

        }

        [Test]
        public void AddShouldCallRespositoryAddMethodOnce()
        {
            var repository = new Mock<IGenericRepository<Rating>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var ratingFactory = new Mock<IRatingFactory>();
            var service = new RatingService(repository.Object, unitOfWork.Object, ratingFactory.Object);
            service.AddRating(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>());
            ratingFactory.Verify(x => x.Create(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void AddShouldCallRespositoryAddMethodWithCorrectUserGuid()
        {
            var user = new Guid();
            var repository = new Mock<IGenericRepository<Rating>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var ratingFactory = new Mock<IRatingFactory>();
            var service = new RatingService(repository.Object, unitOfWork.Object, ratingFactory.Object);
            service.AddRating(user, It.IsAny<int>(), It.IsAny<int>());
            ratingFactory.Verify(x => x.Create(It.Is<Guid>(a=>a==user), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        [Test]
        [TestCase(1)]
        [TestCase(12)]
        [TestCase(14)]
        [TestCase(100)]
        public void AddShouldCallRespositoryAddMethodWithCorrectVenueId(int user)
        {
            var repository = new Mock<IGenericRepository<Rating>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var ratingFactory = new Mock<IRatingFactory>();
            var service = new RatingService(repository.Object, unitOfWork.Object, ratingFactory.Object);
            service.AddRating(It.IsAny<Guid>(), user, It.IsAny<int>());
            ratingFactory.Verify(x => x.Create(It.IsAny<Guid>(), It.Is<int>(arg=>arg==user), It.IsAny<int>()), Times.Once);
        }
        [Test]
        [TestCase(1)]
        [TestCase(12)]
        [TestCase(14)]
        [TestCase(100)]
        public void AddShouldCallRespositoryAddMethodWithCorrectRating(int rating)
        {
            var repository = new Mock<IGenericRepository<Rating>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var ratingFactory = new Mock<IRatingFactory>();
            var service = new RatingService(repository.Object, unitOfWork.Object, ratingFactory.Object);
            service.AddRating(It.IsAny<Guid>(), It.IsAny<int>(), rating);
            ratingFactory.Verify(x => x.Create(It.IsAny<Guid>(), It.IsAny<int>(), It.Is<int>(arg => arg == rating)), Times.Once);
        }
    }
}
