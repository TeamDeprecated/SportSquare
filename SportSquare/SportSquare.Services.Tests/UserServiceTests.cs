using System;
using Moq;
using NUnit.Framework;

using SportSquare.Models;
using SportSquare.Data.Contracts;
using SportSquare.Services.Contracts;
using SportSquare.Models.Factories;

namespace SportSquare.Services.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void ConstructorShouldThrowException_WhenRepositoryIsNull()
        {
            // Arrange
            var userFactory = new Mock<IUserFactory>();
            var unitOfWork = new Mock<IUnitOfWork>();
            IGenericRepository<User> repository = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(repository, unitOfWork.Object, userFactory.Object));
        }

        [Test]
        public void ConstructorShouldThrowException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var userFactory = new Mock<IUserFactory>();
            var repository = new Mock<IGenericRepository<User>>();
            IUnitOfWork unitOfWork = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(repository.Object, unitOfWork, userFactory.Object));
        }


        [Test]
        public void ConstructorShouldThrowException_WhenUserFactoryIsNull()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var repository = new Mock<IGenericRepository<User>>();
            IUserFactory userFactory = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(repository.Object, unitOfWork.Object, userFactory));
        }

        [Test]
        public void ConstructorShouldCreateUserService_WhenDependenciesAreCorrect()
        {
            // Arrange
            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();

            // Act
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);

            // Assert
            Assert.IsNotNull(userService);
        }
    }
}
