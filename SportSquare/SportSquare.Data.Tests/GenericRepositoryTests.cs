using System;
using System.Data.Entity;

using Moq;
using NUnit.Framework;
using SportSquare.Data.Contracts;
using SportSquare.Models.Contracts;
using SportSquare.Data.Repositories;

namespace SportSquare.Data.Tests
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
    }
}
