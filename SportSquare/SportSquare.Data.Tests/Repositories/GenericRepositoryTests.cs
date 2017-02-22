using System;
using System.Data.Entity;

using Moq;
using NUnit.Framework;

using SportSquare.Data.Contracts;
using SportSquare.Models.Contracts;
using SportSquare.Data.Repositories;
using System.Data.Entity.Infrastructure;

namespace SportSquare.Data.Tests.Repositories
{
    [TestFixture]
    public class GenericRepositoryTests
    {
        [Test]
        public void ConstructorShouldThrowException_WhenDbContextIsNull()
        {
            // Arrange
            ISportSquareDbContext dbContext = null;

            Assert.That(
                () => new GenericRepository<IDbModel>(dbContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("DbContext"));
        }

        [Test]
        public void ConstructorShouldThrowException_WhenDbContextDoesntContainsSetOfCurrentType()
        {
            // Arrange
            var dbContext = new Mock<ISportSquareDbContext>();
            dbContext.Setup(db => db.Set<IDbModel>()).Returns<DbSet<IDbModel>>(null);

            Assert.That(
                () => new GenericRepository<IDbModel>(dbContext.Object),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("DbSet"));
        }

        [Test]
        public void ConstructorShouldCreateRepository_WhenDbContextAndDbSetAreExist()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            // Act
            IGenericRepository<IDbModel> genericRepository = new GenericRepository<IDbModel>(mockDbContext.Object);

            // Assert
            Assert.IsNotNull(genericRepository);
        }

        [Test]
        public void ConstructorShouldInvoke_DbContextSetMethodOnce()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            // Act
            IGenericRepository<IDbModel> genericRepository = new GenericRepository<IDbModel>(mockDbContext.Object);

            // Assert
            mockDbContext.Verify(db => db.Set<IDbModel>(), Times.Once);
        }

        [Test]
        public void ConstructorShould_SetCorrectedDbContext()
        {
            // Arrange & Act
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            var fakeGenericRepository = new FakeGenericRepository(mockDbContext.Object);

            Assert.AreSame(mockDbContext.Object, fakeGenericRepository.BaseDbContext);
        }

        [Test]
        public void ConstructorShould_SetCorrectedDbSet()
        {
            // Arrange & Act
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            var fakeGenericRepository = new FakeGenericRepository(mockDbContext.Object);

            // Assert
            Assert.AreSame(mockDbSet.Object, fakeGenericRepository.BaseDbSet);
        }

        [Test]
        public void GetById_ShouldThrow_WhenSearchId_IsNull()
        {
            // Arrange & Act
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            var fakeGenericRepository = new FakeGenericRepository(mockDbContext.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => fakeGenericRepository.GetById(null));
        }

        [Test]
        public void GetById_ShouldInvoke_dbSetFind_WhenSearchId_IsValid()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            var fakeGenericRepository = new FakeGenericRepository(mockDbContext.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<object>())).Returns<IDbModel>(null);

            // Act
            var id = 777;
            fakeGenericRepository.GetById(id);

            // Assert
            mockDbSet.Verify((x) => x.Find(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetById_Should_ReturnSearchedEntity_WhenSearchIdAndEntityExist()
        {
            // Arrange
            var entity = new Mock<IDbModel>();
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            var fakeGenericRepository = new FakeGenericRepository(mockDbContext.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<object>())).Returns(entity.Object);

            // Act
            var id = 777;
            var resultEntity = fakeGenericRepository.GetById(id);

            // Assert
            Assert.AreSame(entity.Object, resultEntity);
        }

        [Test]
        public void GetById_Should_ReturnNUll_WhenSearchIdIsValid_ButEntityDoesntExist()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            var fakeGenericRepository = new FakeGenericRepository(mockDbContext.Object);

            mockDbSet.Setup(mock => mock.Find(It.IsAny<object>())).Returns<IDbModel>(null);

            // Act
            var id = 777;
            var resultEntity = fakeGenericRepository.GetById(id);

            // Assert
            Assert.IsNull(resultEntity);
        }

        [Test]
        public void Add_ShouldThrow_WhenEntityIsNotValid()
        {
            // Arrange & Act
            var mockDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<ISportSquareDbContext>();
            mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

            var fakeGenericRepository = new FakeGenericRepository(mockDbContext.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => fakeGenericRepository.Add(null));
        }


        // TODO !
        //[Test]
        //public void Add_ShouldInvoke_DbSetAdd_WhenAddingEntityIsValid()
        //{
        //    var mockEntity = new Mock<IDbModel>();
        //    var mockDbSet = new Mock<DbSet<IDbModel>>();
        //    var mockDbContext = new Mock<ISportSquareDbContext>();
        //    mockDbContext.Setup(db => db.Set<IDbModel>()).Returns(mockDbSet.Object);

        //    var fakeGenericRepository = new FakeGenericRepository(mockDbContext.Object);

        //    mockDbSet.Setup(mock => mock.Add(It.IsAny<IDbModel>()));

        //    // Act
        //    fakeGenericRepository.Add(mockEntity.Object);

        //    // Assert
        //    mockDbSet.Verify((mock) => mock.Add(It.IsAny<IDbModel>()), Times.Once);
        //}
    }
}
