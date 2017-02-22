using System;
using System.Data.Entity;

using Moq;
using NUnit.Framework;

using SportSquare.Data.Contracts;

namespace SportSquare.Data.Tests.UnitOfWorkTest
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void ConstructorShouldThrowException_WhenDbContextIsNull()
        {
            // Arrange & Act;
            ISportSquareDbContext db = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork.UnitOfWork(db));
        }

        [Test]
        public void ConstructorShouldNotThrow_WhenDbContextIsValid()
        {
            // Arrange & Act;
            var db = new Mock<ISportSquareDbContext>();
            var unitOfWork = new UnitOfWork.UnitOfWork(db.Object);

            // Assert
            Assert.IsNotNull(unitOfWork);
        }

        [Test]
        public void ConstructorShouldCreateInstance_WhenDbContextIsValid()
        {
            // Arrange & Act;
            var db = new Mock<ISportSquareDbContext>();
            var unitOfWork = new UnitOfWork.UnitOfWork(db.Object);
            
            // Assert
            Assert.IsInstanceOf<UnitOfWork.UnitOfWork>(unitOfWork);
        }

        [Test]
        public void UnitOfWork_ShouldImplement_IUnitOfWork_WhenWasCreated()
        {
            // Arrange & Act;
            var db = new Mock<ISportSquareDbContext>();
            var unitOfWork = new UnitOfWork.UnitOfWork(db.Object);

            // Assert
            Assert.IsInstanceOf<UnitOfWork.UnitOfWork>(unitOfWork);
        }

        [Test]
        public void InvokeDbContextCommitMethodOnce()
        {
            // Arrange
            var mockDbContext = new Mock<ISportSquareDbContext>();
            var unitOfWork = new UnitOfWork.UnitOfWork(mockDbContext.Object);

            // Act
            unitOfWork.Commit();

            // Assert
            mockDbContext.Verify(mock => mock.SaveChanges(), Times.Once());
        }
    }
}
